using StackCalculatror.Core.Attributes;
using System;
using System.Collections.Generic;

namespace StackCalculatror.Core
{
    public class NameManager
    {
        public void AddAlias(string originalName, string aliasName)
        {
            if (!CheckCycles(originalName, aliasName))
            {
                _aliases[aliasName] = originalName;
            }
            else
            {
                throw new AliasCycleException();
            }
        }

        public void AddClass(string name, IFunction instance)
        {
            _functionClasses[name] = instance;
        }

        public void AddDelegate(string name, StackFunction function)
        {
            _functions[name] = function;
        }

        public void AddClassFactory(string name, FunctionFactoryMethod factory)
        {
            _functionClassFactory[name] = factory;
        }

        public void AddDelegateFactory(string name, StackFunctionFactoryMethod factory)
        {
            _functionFactory[name] = factory;
        }

        public StackFunction GetFunction(string name)
        {
            var originalName = name;
            while (_aliases.ContainsKey(originalName))
            {
                originalName = _aliases[originalName];
            }
            if (_functionClasses.ContainsKey(originalName))
            {
                return _functionClasses[originalName].Execute;
            }
            if (_functions.ContainsKey(originalName))
            {
                return _functions[originalName];
            }
            if (_functionClassFactory.ContainsKey(originalName))
            {
                return _functionClassFactory[originalName]().Execute;
            }
            if (_functionFactory.ContainsKey(originalName))
            {
                return _functionFactory[originalName]();
            }
            return null;
        }

        public IEnumerable<string> GetAllNames()
        {
            List<string> result = new List<string>();
            result.AddRange(_aliases.Keys);
            result.AddRange(_functionClasses.Keys);
            result.AddRange(_functions.Keys);
            result.AddRange(_functionClassFactory.Keys);
            result.AddRange(_functionFactory.Keys);
            return result;
        }

        private bool CheckCycles(string originalName, string aliasName)
        {
            var name = originalName;
            while (true)
            {
                if (!_aliases.ContainsKey(name))
                {
                    return false;
                }
                name = _aliases[name];
                if (name == aliasName)
                {
                    return true;
                }
            }
        }

        private readonly Dictionary<string, string> _aliases = new Dictionary<string, string>();
        private readonly Dictionary<string, IFunction> _functionClasses = new Dictionary<string, IFunction>();
        private readonly Dictionary<string, StackFunction> _functions = new Dictionary<string, StackFunction>();
        private readonly Dictionary<string, FunctionFactoryMethod> _functionClassFactory = new Dictionary<string, FunctionFactoryMethod>();
        private readonly Dictionary<string, StackFunctionFactoryMethod> _functionFactory = new Dictionary<string, StackFunctionFactoryMethod>();
    }
}
