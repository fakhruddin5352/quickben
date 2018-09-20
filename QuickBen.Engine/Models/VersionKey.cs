using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBen.Engine.Models
{
    public class VersionKey
    {
        public static VersionKey<T> By<T>(T id) 
        {
            return new VersionKey<T> { Id = id };
        }
        public static VersionKey<T> By<T>(T id, int? version)
        {
            return new VersionKey<T> { Id = id, Version = version };
        }

        public static VersionKey<T> By<T>(T id, object version)
        {
            var strVersion = version?.ToString();
            int? v = null;
            if (!string.IsNullOrEmpty(strVersion))
            {
                v = int.Parse(strVersion);
            }
            return new VersionKey<T> { Id = id, Version = v};
        }

    }
    public class VersionKey<T>
    {
        public static VersionKey<T> By(T id)
        {
            return new VersionKey<T> {Id=id};
        }
        public static VersionKey<T> By(T id,int? version)
        {
            return new VersionKey<T> { Id = id,Version=version };
        }
        public static VersionKey<T> InitialVersion(T id)
        {
            return new VersionKey<T> { Id = id, Version = INITIAL_VERSION };
        }
        public T Id { get; set; }

        public int? Version { get; set; }


        public bool VersionSpecified => Version.HasValue;

        public const int INITIAL_VERSION=1;

        protected bool Equals(VersionKey<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Id, other.Id) && Version == other.Version;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((VersionKey<T>) obj);
        }

        public VersionKey<T> ToLatestVersion()
        {
            return VersionKey<T>.By(Id);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(Id)*397) ^ Version.GetHashCode();
            }
        }
    }
}
