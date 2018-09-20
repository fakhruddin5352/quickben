using System;
using System.Collections.Generic;

namespace QuickBen.Engine
{
    public class WorkflowInstanceContext
    {
        public string WorkflowInstanceId { get; set; }

        public string WorkflowId { get; set; }

        public int WorkflowVersion { get; set; }

        public DateTime LastResumeDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<string> RequiredParameters { get; set; }  
    }
}