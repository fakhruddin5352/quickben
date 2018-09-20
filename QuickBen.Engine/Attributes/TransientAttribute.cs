﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBen.Engine.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,
        Inherited = true,
        AllowMultiple = false)]
    public class TransientAttribute : Attribute
    {
    }
}
