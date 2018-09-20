using System;

namespace QuickBen.Engine.Models
{
    public class StepParam
    {
        public string Id { get; set; }

        public string StepId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public StepParamType Type { get; set; }

        public bool Required { get; set; }

        protected bool Equals(StepParam other)
        {
            return string.Equals(StepId, other.StepId) && string.Equals(Key, other.Key) && string.Equals(Value, other.Value) && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StepParam) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (StepId != null ? StepId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Key != null ? Key.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) Type;
                return hashCode;
            }
        }
    }
}
