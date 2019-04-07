using System;
using System.Collections.Generic;
using System.Text;

namespace Bve5_Parsing.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ArgumentAttribute: Attribute
    {
        public bool Optional { get; set; } = false;
    }
}
