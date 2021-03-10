using System;

namespace StackCalculatror.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class OutputTypeAttribute : Attribute
    {
        public OutputTypeAttribute(Type outputType)
        {
            OutputType = outputType;
        }

        public Type OutputType { get; set; }
    }
}
