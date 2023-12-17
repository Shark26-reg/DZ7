using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CustomNameAttribute : Attribute
    {
        public string Name { get; }

        public CustomNameAttribute(string name)
        {
            Name = name;
        }
    }
}
