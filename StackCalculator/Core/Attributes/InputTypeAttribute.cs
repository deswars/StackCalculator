using System;

namespace StackCalculatror.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InputTypeAttribute : Attribute
    {
        public InputTypeAttribute(Type inputType)
        {
            InputType = inputType;
        }

        public Type InputType { get; set; }
    }
}
