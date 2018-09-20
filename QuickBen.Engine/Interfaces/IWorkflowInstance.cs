using System.Threading.Tasks;

namespace QuickBen.Engine.Interfaces
{
    public interface IWorkflowInstance
    {
        string Id { get; }
        Task Initialize();
        Task<WorkflowStepState> Execute();
        Task<WorkflowStepState> Resume();
    }
}