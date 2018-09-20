using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickBen.Engine.Interfaces
{
    public interface IWorkflowStep
    {
        string Name { get; set; }

        /// <summary>
        /// Unique id for a workflow instance
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Corresponds to the Id of the Step
        /// </summary>
        string StepConfigId { get; set; }
        
//        WorkflowStepState StepState { get; }

        void Initialize();

        Task<WorkflowStepState> Execute();

        Task<WorkflowStepState> Resume();
    }
}