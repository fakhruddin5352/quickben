using QuickBen.Engine.Interfaces;
using System;

namespace QuickBen.Engine
{
    [Serializable]
    public class Controller : IWorkflowEngineControl
    {
        private readonly IWorkflowContextPersistor persistor;
        private readonly WorkflowContext context;

        public Controller(IWorkflowContextPersistor persistor, WorkflowContext context)
        {
            this.persistor = persistor;
            this.context = context;
        }

        public void Persist()
        {
            persistor.Save(context);
        }
    }
}