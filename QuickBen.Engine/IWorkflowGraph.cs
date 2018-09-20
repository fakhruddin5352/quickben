using QuickBen.Engine.Interfaces;
using System.Collections.Generic;
using QuickBen.Engine.Models;

namespace QuickBen.Engine
{
    public interface IWorkflowGraph
    {

        Dictionary<string, IEnumerable<StepParam>> StepsConfiguration { get; }

        IEnumerable<IWorkflowStep> Steps { get; }
    }
}