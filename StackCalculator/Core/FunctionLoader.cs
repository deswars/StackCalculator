using StackCalculatror.Core.Attributes;
using System;
using System.Reflection;

namespace StackCalculatror.Core
{
    public class FunctionLoader
    {
        public FunctionLoader(NameManager nameManager)
        {
            _nameManager = nameManager;
        }

        public void LoadFunctionsFromAssemblyPath(string location)
        {
            var assembly = Assembly.LoadFile(location);
            LoadFunctionsFromAssembly(assembly);
        }


        public void LoadFunctionsFromAssembly(Assembly assembly)
        {
            var typesInAssembly = assembly.GetTypes();
            foreach (var type in typesInAssembly)
            {
                var attribute = type.GetCustomAttribute<FunctionClassAttribute>();
                if (attribute != null)
                {
                    var name = attribute.Name;

                    var constructor = type.GetConstructor(new Type[0]);
                    var instance = (IFunction)(constructor.Invoke(new object[0]));
                    _nameManager.AddClass(name, instance);

                    var aliasesAttribute = type.GetCustomAttributes<FunctionAliasAttribute>();
                    foreach (var functionAliasAttribute in aliasesAttribute)
                    {
                        _nameManager.AddAlias(name, functionAliasAttribute.Alias);
                    }
                }
                else
                {
                    var typeMethods = type.GetMethods();
                    foreach (var method in typeMethods)
                    {
                        if (method.IsStatic)
                        {
                            var functionAttribute = method.GetCustomAttribute<FunctionAttribute>();
                            if (functionAttribute != null)
                            {
                                var newMethod = (StackFunction)Delegate.CreateDelegate(typeof(StackFunction), method);
                                var name = functionAttribute.Name;
                                _nameManager.AddDelegate(name, newMethod);

                                var aliasesAttribute = method.GetCustomAttributes<FunctionAliasAttribute>();
                                foreach (var functionAliasAttribute in aliasesAttribute)
                                {
                                    _nameManager.AddAlias(name, functionAliasAttribute.Alias);
                                }
                            }
                        }
                    }
                }
            }
        }

        private NameManager _nameManager;
    }
}
