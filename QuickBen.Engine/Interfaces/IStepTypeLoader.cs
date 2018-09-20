using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBen.Engine.Interfaces
{
    public interface IStepTypeLoader
    {
        Type Load(string typeName, string path ,string workflowId, int version);
    }
}
