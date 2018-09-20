using Newtonsoft.Json.Linq;
using QuickBen.Engine.Interfaces;
using QuickBen.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace QuickBen.Engine
{
    public class DefaultStepExecutor : IStepExecutor
    {

        private readonly IContextInjector contextInjector;


        public DefaultStepExecutor(IContextInjector contextInjector)
        {
            this.contextInjector = contextInjector;
        }

        public async Task<WorkflowStepState> Execute(IWorkflowStep step,WorkflowContext context,IList<StepParam> sParams)
        {
            context.CurrentStepsIds = new[] { step.Id };
            contextInjector.InjectInstanceContextInStep(CreateWorkflowInstanceContext(context),step,sParams);
            contextInjector.InjectInputParametersInStep(context, step, sParams);
            if (context.RequiredParameters.Any())
                return WorkflowStepState.InputRequired;

            var state = await step.Execute();
            CheckStepState(step,context,state, sParams);
            return state;
        }

        private static WorkflowInstanceContext CreateWorkflowInstanceContext(WorkflowContext context)
        {
            return new WorkflowInstanceContext()
            {
                WorkflowInstanceId = context.WorkflowInstanceId,WorkflowId = context.WorkflowId,
                RequiredParameters = context.RequiredParameters
            };
        }

        public async Task<WorkflowStepState> Resume(IWorkflowStep step, WorkflowContext context, IList<StepParam> sParams)
        {

            context.CurrentStepsIds = new[] { step.Id };
            contextInjector.InjectInstanceContextInStep(CreateWorkflowInstanceContext(context), step, sParams);
            contextInjector.InjectInputParametersInStep(context, step, sParams);
            if (context.RequiredParameters.Any())
                return WorkflowStepState.InputRequired;


            if (context.LocalContexts.ContainsKey(step.Id))
            {
                contextInjector.InjectLocalContextInStep(context, step,sParams);
            }

            var state = await step.Resume();
            CheckStepState(step,context,state, sParams);
            return state;
        }

        private void CheckStepState(IWorkflowStep step,WorkflowContext context, WorkflowStepState state, IList<StepParam> sParams)
        {
            if (state == WorkflowStepState.InputRequired)
            {
                // Set the local context
                if (!context.LocalContexts.ContainsKey(step.Id))
                {
                    context.LocalContexts.Add(step.Id, new JObject());
                }
                contextInjector.SetLocalContext(step, context, sParams);
            }
            else
            {
                context.CurrentStepsIds = null;
            }

            contextInjector.SetOutputParameters(step, context, sParams);
        }
        
     
    }
}
