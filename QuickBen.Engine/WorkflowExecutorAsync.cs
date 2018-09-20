using System;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using QuickBen.Engine.Interfaces;

namespace QuickBen.Engine
{
    public class WorkflowExecutorAsync
    {


        public WorkflowExecutorAsync()
        {
        }

        //This is all in another app Domain
        public async Task<WorkflowState> Start(IWorkflowContextPersistor persistor, IWorkflowLoader loader, string workflowId, int version, string systemId, string initialData)
        {
            WorkflowContext context = new WorkflowContext(workflowId, version, systemId)
            {
                GlobalParameters = JObject.Parse(initialData)
            };
            var result = await CreateGraphAndExecute(context, loader, persistor);
            return result;
        }

        public async Task<WorkflowState> Resume(IWorkflowContextPersistor persistor, IWorkflowLoader loader, string workflowInstanceId, string data)
        {
            var context = persistor.Load(workflowInstanceId);
            if (context == null)
            {
                throw new WorkflowEngineException("Workflow context can not be null");
            }

            if (string.IsNullOrWhiteSpace(context.WorkflowId))
            {
                throw new WorkflowEngineException("workflowId is missing in the route");
            }


            context.MergeGlobalContexts(JObject.Parse(data));

            var result = await CreateGraphAndExecute(context, loader, persistor, true);
            return result;
        }

        private async Task<WorkflowState> CreateGraphAndExecute(WorkflowContext context, IWorkflowLoader loader, IWorkflowContextPersistor instancePersistor, bool isResume = false)
        {
            IWorkflowInstance workflowInstance = loader.LoadWorkflow(context.WorkflowId, context.WorkflowVersion, context
, new Controller(instancePersistor, context));
            await workflowInstance.Initialize();
            var state = isResume ? await workflowInstance.Resume() : await workflowInstance.Execute();
            instancePersistor.Save(context);
            return new WorkflowState() { Context = context.ToJson(), Id = workflowInstance.Id, State = state };
        }

    }
}