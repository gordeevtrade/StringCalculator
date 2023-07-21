using System.Globalization;

namespace CalculateMathExpressions

{
    public class ReversePolishNotation
    {
        private Connector _connector;

        public ReversePolishNotation(Connector connector)
        {
            _connector = connector;
        }

        public string PosfixForm(string mathexpressionInput)
        {
            string infixExpr = RemoveSpace(mathexpressionInput);
            string postfixExpr = String.Empty;
            Stack<char> stack = new();

            for (int i = 0; i < infixExpr.Length; i++)
            {
                char element = infixExpr[i];

                if (Char.IsDigit(element) || element == _connector.DecimalSeparator || element == _connector.ThousandSeparator)
                {
                    postfixExpr += GetStringNumber(infixExpr, ref i) + " ";
                }
                else if (element.Equals('('))
                {
                    stack.Push(element);
                }

                else if (element == '^')
                {
                    while (stack.Count > 0 && (stack.Peek().Equals('^')))
                    {
                        postfixExpr += stack.Pop();
                    }
                    stack.Push(element);
                }

                else if (element.Equals(')'))
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                        postfixExpr += stack.Pop();
                    stack.Pop();
                }
                else if (Operators.OperationPriority.ContainsKey(element))
                {
                    char operators = element;

                    if (operators.Equals('-') && (i == 0 || (i > 1 && Operators.OperationPriority.ContainsKey(infixExpr[i - 1]))))
                        operators = '~';


                    if (operators.Equals('+') && (i == 0 || (i > 1 && Operators.OperationPriority.ContainsKey(infixExpr[i - 1]))))
                        operators = '$';


                    while (stack.Count > 0 && (Operators.OperationPriority[stack.Peek()] >= Operators.OperationPriority[operators]))
                        postfixExpr += stack.Pop();
                    stack.Push(operators);
                }
            }
            foreach (char element in stack)
                postfixExpr += element;

            return postfixExpr;
        }

        private string RemoveSpace(string mathExpression)
        {
            string expression = string.Join("", mathExpression.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            return expression;
        }

        private string GetStringNumber(string expr, ref int pos)
        {
            string strNumber = "";

            for (; pos < expr.Length; pos++)
            {
                char number = expr[pos];

                if (Char.IsDigit(number) || number == _connector.DecimalSeparator || number == _connector.ThousandSeparator)
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
