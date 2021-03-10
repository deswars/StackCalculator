using System;

namespace StackCalculatror.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FunctionClassAttribute : Attribute
    {
        public FunctionClassAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
