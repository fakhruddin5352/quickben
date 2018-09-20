using System;

namespace QuickBen.Engine.Interfaces
{
    [Serializable]
    public class WorkflowState
    {
        public string Id { get; set; }
        public string Context { get; set; }
        public string[] RequiredParameters { get; set; }
        public WorkflowStepState State { get; set; }
    }
}