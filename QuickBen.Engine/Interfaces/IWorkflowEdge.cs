namespace QuickBen.Engine.Interfaces
{
    public interface IWorkflowEdge
    {
        string Id { get; set; }

        ICondition Condition { get; set; }

        IWorkflowNode Node { get; }
    }
}