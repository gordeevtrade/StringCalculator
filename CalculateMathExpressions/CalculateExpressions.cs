using System.Globalization;

namespace CalculateMathExpressions
{
    public class CalculateExpressions
    {

        private string _divideByZero = "divide by zero";

        private Connector _connector;
        public CalculateExpressions(Connector connector)
        {
            _connector = connector;
        }

        public string CalculateExpression(string postfixExpr)
        {
            Stack<double> locals = new();

            string result = String.Empty;

            for (int i = 0; i < postfixExpr.Length; i++)
            {
                char element = postfixExpr[i];

                if (Char.IsDigit(element) || element.Equals(_connector.DecimalSeparator) || element.Equals(_connector.ThousandSeparator))
                {
                    string number = GetStringNumber(postfixExpr, ref i);
                    locals.Push(double.Parse(number));
                }

                else if (Operators.OperationPriority.ContainsKey(element))
                {
                    if (element.Equals('~'))
                    {
                        double last = locals.Count > 0 ? locals.Pop() : 0;
                        locals.Push(Execute('-', 0, last));
                        continue;
                    }

                    if (element.Equals('$'))
                    {
                        double last = locals.Count > 0 ? locals.Pop() : 0;
                        locals.Push(Execute('+', 0, last));
                        continue;
                    }

                    double second = locals.Count > 0 ? locals.Pop() : 0;
                    double first = locals.Count > 0 ? locals.Pop() : 0;

                    if (element.Equals('/') && second == 0)
                    {
                        return _divideByZero;
                    }

                    locals.Push(Execute(element, first, second));
                }
            }
            result = locals.Pop().ToString();
            return result;
        }


        private double Execute(char op, double first, double second) => op switch
        {
            '+' => first + second,
            '-' => first - second,
            '*' => first * second,
            '/' => first / second,
            '^' => Math.Pow(first, second),
            _ => 0
        };
        private string GetStringNumber(string expr, ref int pos)
        {
            string strNumber = "";

            for (; pos < expr.Length; pos++)
            {
                char number = expr[pos];

                if (Char.IsDigit(number) || number.Equals(_connector.DecimalSeparator) || number.Equals(_connector.ThousandSeparator))
                    strNumber += number;
                else
                {
                    pos--;
                    break;
                }
            }
            return strNumber;
        }
    }

}
