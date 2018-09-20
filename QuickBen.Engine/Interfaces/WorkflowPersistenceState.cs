using System.Collections.Generic;

namespace QuickBen.Engine.Interfaces
{
    public class WorkflowPersistenceState
    {
        public string Context { get; set; }
        public string InstanceId { get; set; }
        public IDictionary<string, string> LocalContexts  { get; set; }
    }
}