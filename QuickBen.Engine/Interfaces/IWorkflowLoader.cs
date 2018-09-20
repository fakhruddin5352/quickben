using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBen.Engine.Interfaces
{
    public interface IWorkflowLoader
    {
        IWorkflowInstance LoadWorkflow(string id, int version, WorkflowContext context, IWorkflowEngineControl control);
    }
}
