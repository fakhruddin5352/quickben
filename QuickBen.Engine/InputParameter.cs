using System.Collections.Generic;

namespace QuickBen.Engine
{
    public sealed class InputParameter<T>
    {
        private readonly T value;

        public string Name { get; private set; }

        public InputParameter(string name, T value)
        {
            Name = name;
            this.value = value;
        }

        public T Get()
        {
            return value;
        }

        public bool IsFilled()
        {
            return value != null;
        }
    }
}
