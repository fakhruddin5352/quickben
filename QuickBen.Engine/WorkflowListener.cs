using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickBen.Engine.Models;

namespace QuickBen.Engine
{
    public delegate void WorkflowLoadedEventHandler( VersionKey<string> workflowId);
    public delegate void WorkflowCompletedEventHandler(VersionKey<string> workflowId,string workflowInstanceId);
    public delegate void WorkflowPersistedEventHandler(VersionKey<string> workflowId, string workflowInstanceId);
    public delegate void WorkflowResumedEventHandler(VersionKey<string> workflowId, string workflowInstanceId);

    public class WorkflowListener
    {
        public event WorkflowLoadedEventHandler Loaded;
    }

    public delegate void WorkflowEngineInitialized();
    
}
