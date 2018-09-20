using System.Threading.Tasks;

namespace QuickBen.Engine.Interfaces
{
    public interface IWorkflowEngine
    {
        Task<WorkflowState> StartWorkflow(string workflowId, int version, string systemId, string initialData);
        Task<WorkflowState> ResumeWorkflow(string workflowId, int version, string workflowInstanceId, string data);

    }
}