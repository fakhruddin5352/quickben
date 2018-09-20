using System;

namespace QuickBen.Engine.Attributes
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field, 
        Inherited = true, 
        AllowMultiple = false)]
    public class LocalParameterAttribute:Attribute
    {
    }

}
