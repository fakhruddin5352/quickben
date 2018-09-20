using Newtonsoft.Json.Linq;
using QuickBen.Engine.Models;
using System.Collections;
using System.Collections.Generic;

namespace QuickBen.Engine.Interfaces
{
    public interface IContextInjector
    {
        /// <summary>
        /// Check the config and inject the input parameters into the step
        /// </summary>
        /// <param name="context">The context to inject in</param>
        /// <param name="step">The step</param>
        /// <param name="stepConfig">The step configuration</param>
        void InjectInputParametersInStep(WorkflowContext context, IWorkflowStep step, IEnumerable<StepParam> stepConfig);



        /// <summary>
        /// Set output parameter in the context passed in parameter
        /// </summary>
        /// <param name="step">The step containing output params</param>
        /// <param name="context">The context</param>
        /// <param name="stepConfig">The step configuration</param>
        void SetOutputParameters(IWorkflowStep step, WorkflowContext context, IEnumerable<StepParam> stepConfig);


        /// <summary>
        /// Set the local context of a step
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="context">The local context that will be filled</param>
        void SetLocalContext(IWorkflowStep step, WorkflowContext context, IEnumerable<StepParam> stepConfig);

        /// <summary>
        /// Inject the local context in a step (used for a resume)
        /// </summary>
        /// <param name="context">The local context</param>
        /// <param name="step">The step</param>
        void InjectLocalContextInStep(WorkflowContext context, IWorkflowStep step, IEnumerable<StepParam> stepConfig);

        void InjectInstanceContextInStep(WorkflowInstanceContext context, IWorkflowStep step, IEnumerable<StepParam> stepConfig);
    }
}
