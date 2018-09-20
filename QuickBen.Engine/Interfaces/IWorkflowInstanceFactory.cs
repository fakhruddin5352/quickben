using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBen.Engine.Interfaces
{
    public interface IWorkflowInstanceFactory
    {
        IWorkflowInstance CreateInstance(IWorkflowGraph graph,WorkflowContext context);
    }
}
