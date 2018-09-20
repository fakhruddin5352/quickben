using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBen.Engine
{
    public class OutputParameter
    {
        private object value;


        public string Name { get; private set; }

        public bool IsSet { get; private set; }
        
        public OutputParameter(string name)
        {
            Name = name;
        }

        public object Get()
        {
            return value;
        }

        public void Reset()
        {
            IsSet = false;
        }

        public void Set(object val)
        {
            this.value = val;
            IsSet = true;
        }
    }
}