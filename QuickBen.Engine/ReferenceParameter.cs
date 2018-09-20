namespace QuickBen.Engine
{
    public sealed class ReferenceParameter<T>
    {
        public string Name { get; private set; }

        public T Value { get; set; }

        public ReferenceParameter(string name,T value)
        {
            Name = name;
            Value = value;
        }
    }
}