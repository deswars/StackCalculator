using System;
using System.Collections.Generic;

namespace StackCalculatror.Core
{
    public delegate void StackFunction(Stack<object> stack);

    public interface IFunction
    {
        void Execute(Stack<object> stack);
        IEnumerable<Type> GetInputTypes();
        IEnumerable<Type> GetOutputTypes();
    }
}
