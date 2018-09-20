using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBen.Engine.Interfaces
{
    public interface IWorkflowContextPersistor
    {
        WorkflowContext Load(string instanceId);
        WorkflowPersistenceState Save(WorkflowContext context);
        void Delete(string instanceId);

    }
}
