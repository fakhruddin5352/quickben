using System.Collections.Generic;

namespace QuickBen.Engine.Interfaces
{
    public interface IWorkflowNode
    {
        string Id { get; set; }

        string Name { get; set; }

        IWorkflowStep Step { get; }

        IList<IWorkflowEdge> Edges { get; } 
    }
}