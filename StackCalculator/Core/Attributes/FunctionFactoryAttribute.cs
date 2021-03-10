using System;

namespace StackCalculatror.Core.Attributes
{
    public delegate StackFunction StackFunctionFactoryMethod();

    public delegate IFunction FunctionFactoryMethod();

    [AttributeUsage(AttributeTargets.Class)]
    public class FunctionFactoryAttribute : Attribute
    {
        public FunctionFactoryAttribute(string method)
        {
            Method = method;
        }

        public string Method { get; set; }
    }
}
