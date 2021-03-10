using StackCalculatror.Core.Attributes;
using System;
using System.Collections.Generic;

namespace StackCalculatror.Core
{
    public class IntegerConstantFunction : IFunction
    {
        public IntegerConstantFunction(int value)
        {
            _value = value;
        }

        public void Execute(Stack<object> stack)
        {
            stack.Push(_value);
        }

        public IEnumerable<Type> GetInputTypes()
        {
            return new Type[0];
        }

        public IEnumerable<Type> GetOutputTypes()
        {
            return new[] { typeof(int) };
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        private readonly int _value;
    }
}
