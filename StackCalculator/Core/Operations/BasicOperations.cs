using System;
using System.Collections.Generic;
using StackCalculatror.Core.Attributes;

namespace StackCalculatror.Core.Operations
{
    public class BasicOperations
    {
        [Function("Add"), FunctionAlias("+"), InputType(typeof(int)), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Add(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var second = (int)stack.Pop();
            var result = first + second;
            stack.Push(result);
        }


        [Function("Substract"), FunctionAlias("-"), InputType(typeof(int)), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Substract(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var second = (int)stack.Pop();
            var result = second - first;
            stack.Push(result);
        }


        [Function("Multiply"), FunctionAlias("*"), InputType(typeof(int)), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Multiply(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var second = (int)stack.Pop();
            var result = first * second;
            stack.Push(result);
        }


        [Function("Divide"), FunctionAlias("/"), InputType(typeof(int)), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Divide(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var second = (int)stack.Pop();
            var result = second / first;
            stack.Push(result);
        }

        [Function("Exponent"), FunctionAlias("**"), InputType(typeof(int)), InputType(typeof(int)), OutputType(typeof(int))]
        public static void Exponent(Stack<object> stack)
        {
            var first = (int)stack.Pop();
            var second = (int)stack.Pop();
            var result = 1;
            if (first >= 0)
            {
                for (int i = 0; i < first; i++)
                {
                    result *= second;
                }
            }
            else
            {
                result = 0;
            }
            stack.Push(result);
        }
    }
}
