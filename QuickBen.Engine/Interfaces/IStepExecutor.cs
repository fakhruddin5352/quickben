using QuickBen.Engine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickBen.Engine.Interfaces
{
    public interface IStepExecutor
    {

        Task<WorkflowStepState> Execute(IWorkflowStep step, WorkflowContext context, IList<StepParam> parameters);

        Task<WorkflowStepState> Resume(IWorkflowStep step, WorkflowContext context, IList<StepParam> parameters);
    }
}
