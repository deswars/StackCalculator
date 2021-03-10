using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StackCalculatror.Core;

namespace StackCalculatror.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameManager = new NameManager();
            var loader = new FunctionLoader(nameManager);
            var parser = new ExpressionParser(nameManager);

            //loader.LoadFunctionsFromAssembly("D:\\StackArithmeticCoreFunctions.dll");
            //var expression = parser.Parse("5 2 + 5 1 + -");
            loader.LoadFunctionsFromAssembly(typeof(NameManager).Assembly);

            while (true)
            {
                Console.WriteLine("Supported commands: 'load' ");
                Console.WriteLine("1)load");
                Console.WriteLine("2)execute");
                Console.WriteLine("3)exit");
                Console.Write("#: ");
                var command = Console.ReadLine();
                var commandElements = command.Split(' ');
                switch (commandElements[0])
                {
                    case "load":
                        LoadAssembly(loader, commandElements.Skip(1));
                        break;
                    case "execute":
                        Execute(parser, commandElements.Skip(1));
                        break;
                    case "exit":
                        return;
                }
            }

        }

        static void LoadAssembly(FunctionLoader loader, IEnumerable<string> assemblyList)
        {
            foreach (var assemblyPath in assemblyList)
            {
                loader.LoadFunctionsFromAssemblyPath(assemblyPath);
                Console.WriteLine("{0} loaded", assemblyPath);
            }
        }

        static void Execute(ExpressionParser parser, IEnumerable<string> expressionLexems)
        {
            string input;
            var enumerable = expressionLexems as string[] ?? expressionLexems.ToArray();
            if (enumerable.Any())
            {
                input = String.Join(" ", enumerable);
            }
            else
            {
                Console.WriteLine("Input expression");
                input = Console.ReadLine();
            }
            try
            {
                var expression = parser.Parse(input);
                var stack = new Stack<object>();
                expression(stack);
                foreach (var outputElement in stack)
                {
                    Console.WriteLine(outputElement);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("!!!!! ERROR !!!!!");
            }
        }
    }
}
