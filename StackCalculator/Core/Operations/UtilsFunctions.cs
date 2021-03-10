using System;
using System.Collections.Generic;
using StackCalculatror.Core.Attributes;

namespace StackCalculatror.Core
{
    public class UtilsFunctions
    {
        [Function("Compare"), FunctionAlias("=="), InputType(typeof(int)), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Compare(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var second = (int)stack.Pop();
            var result = second.CompareTo(first);
            stack.Push(result);
        }

        [Function("Duplicate"), FunctionAlias("Copy"), FunctionAlias("Peek"), InputType(typeof(int)), OutputType(typeof(int)), OutputType(typeof(int))]
        public static void Duplicate(Stack<object> stack)
        {
            var first = stack.Peek();
            stack.Push(first);
        }
    }
}
