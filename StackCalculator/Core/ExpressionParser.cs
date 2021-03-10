using System;

namespace StackCalculatror.Core
{
    public class ExpressionParser
    {
        public ExpressionParser(NameManager nameManager)
        {
            _nameManager = nameManager;
        }

        public StackFunction Parse(string input)
        {
            StackFunction result = null;
            var lexemList = input.Split(' ');
            foreach (var lexem in lexemList)
            {
                int number;
                var isNumber = int.TryParse(lexem, out number);
                if (isNumber)
                {
                    var constant = new IntegerConstantFunction(number);
                    result += constant.Execute;
                }
                else
                {
                    var function = _nameManager.GetFunction(lexem);
                    if (function != null)
                    {
                        result += function;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return result;
        }

        private readonly NameManager _nameManager;
    }
}
