using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuickBen.Engine.Interfaces;

namespace QuickBen.Engine
{
    [Serializable]
    public class WorkflowExecutor : MarshalByRefObject
    {

        public WorkflowExecutor()
        {
        }

        //This is all in another app Domain
        public WorkflowState Start(string instancePersistor, string loader ,string workflowId, int version, string systemId, string initialData)
        {
            var ip = (IWorkflowContextPersistor)Activator.CreateInstance(Type.GetType(instancePersistor));
            var ll = (IWorkflowLoader)Activator.CreateInstance(Type.GetType(loader));

            WorkflowContext context = new WorkflowContext(workflowId, version, systemId)
            {
                GlobalParameters = JObject.Parse(initialData)
            };
            var result =  CreateGraphAndExecute(context,ll,ip);
            return result;
        }

        public WorkflowState Resume(string instancePersistor, string loader, string workflowInstanceId, string data)
        {
            var ip = (IWorkflowContextPersistor)Activator.CreateInstance(Type.GetType(instancePersistor));
            var ll = (IWorkflowLoader)Activator.CreateInstance(Type.GetType(loader));

            var context = ip.Load(workflowInstanceId);
            if (context == null)
            {
                throw new WorkflowEngineException("Workflow context can not be null");
            }

            if (string.IsNullOrWhiteSpace(context.WorkflowId))
            {
                throw new WorkflowEngineException("workflowId is missing in the route");
            }


            context.TransientTokens.Clear();
            context.RequiredParameters.Clear();
            context.MergeGlobalContexts(JObject.Parse(data));

            var result =  CreateGraphAndExecute(context,ll,ip,true);
            return result;
        }

        private WorkflowState CreateGraphAndExecute(WorkflowContext context,IWorkflowLoader loader,IWorkflowContextPersistor instancePersistor, bool isResume = false)
        {
            IWorkflowInstance workflowInstance = loader.LoadWorkflow(context.WorkflowId, context.WorkflowVersion,context
, new Controller(instancePersistor, context));
            workflowInstance.Initialize().Wait();
            var state = isResume ?  workflowInstance.Resume().Result :workflowInstance.Execute().Result;
            var persistentState = instancePersistor.Save(context);
            return new WorkflowState()
            {
                Context = persistentState.Context,
                Id = persistentState.InstanceId,
                State = state,
                RequiredParameters = context.RequiredParameters.ToArray()
            };

        }
    }
}