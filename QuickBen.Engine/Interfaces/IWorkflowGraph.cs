using System.Collections.Generic;
using QuickBen.Engine.Interfaces;
using QuickBen.Engine.Models;

namespace QuickBen.Engine.Interfaces
{
    public interface IWorkflowGraph
    {
        Dictionary<string, IEnumerable<StepParam>> StepsConfiguration { get; }
        IList<IWorkflowStep> Steps { get; }
        IWorkflowNode RootNode { get;  }
    }
}