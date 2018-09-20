using System;

namespace QuickBen.Engine
{
    [Serializable]
    public class WorkflowEngineException : Exception
    {
        public WorkflowEngineException()
        {
        }

        public WorkflowEngineException(string message)
            : base(message)
        {
        }

        public WorkflowEngineException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        
        
    }
}
