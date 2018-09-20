using QuickBen.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBen.Engine.Conditions
{
    class NullCondition:ICondition
    {
        public Task<bool> CanFire(WorkflowContext context)
        {
            return Task.FromResult(true);
        }
    }
}
