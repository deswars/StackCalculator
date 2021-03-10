using StackCalculatror.Core.Attributes;
using System;
using System.Collections.Generic;

namespace BinaryOperations
{
    public class BinaryOperations
    {
        [Function("And"), FunctionAlias("&"), InputType(typeof(int)), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Add(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var second = (int)stack.Pop();
            var result = first & second;
            stack.Push(result);
        }

        [Function("Or"), FunctionAlias("|"), InputType(typeof(int)), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Or(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var second = (int)stack.Pop();
            var result = first | second;
            stack.Push(result);
        }

        [Function("Xor"), FunctionAlias("^"), InputType(typeof(int)), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Xor(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var second = (int)stack.Pop();
            var result = first ^ second;
            stack.Push(result);
        }

        [Function("Not"), FunctionAlias("~"), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Not(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var result = ~first;
            stack.Push(result);
        }
    }
}
