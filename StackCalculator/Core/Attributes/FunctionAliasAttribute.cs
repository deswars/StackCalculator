using System;

namespace StackCalculatror.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class FunctionAliasAttribute : Attribute
    {
        public FunctionAliasAttribute(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; set; }
    }
}
