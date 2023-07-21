namespace Validation
{
    public class OperatorsValidation
    {
        public bool IsCorrectOperators(string inputMathExpression)
        {
            if (IsOperator(inputMathExpression[inputMathExpression.Length - 1]))
            {
                return false;
            }

            for (int i = 0; i < inputMathExpression.Length; i++)
            {

                if (i == 0)
                {
                    if (inputMathExpression[i].Equals('/') || inputMathExpression[i].Equals('*') || inputMathExpression[i].Equals('^'))
                        return false;

                    if (inputMathExpression[i].Equals('-') || inputMathExpression[i].Equals('+'))
                        continue;
                }

                if (IsOperator(inputMathExpression[i]) && IsOperator(inputMathExpression[i + 1]) && IsOperator(inputMathExpression[i + 2]))
                {
                    return false;
                }

                if ((inputMathExpression[i].Equals('/') || inputMathExpression[i].Equals('*') || inputMathExpression[i].Equals('^')) && inputMathExpression[i - 1].Equals('('))
                {
                    return false;
                }

                if ((inputMathExpression[i].Equals('^')) && (!char.IsNumber(inputMathExpression[i - 1]) && inputMathExpression[i - 1] != ')')) {
                    return false;
                }

                if ((i != 0 && inputMathExpression[i].Equals(')')) && IsOperator(inputMathExpression[i - 1]))
                {
                    return false;
                }

                if (IsOperator(inputMathExpression[i]) && IsOperator(inputMathExpression[i + 1]))
                {
                    return CheckTwoOperators(inputMathExpression[i], inputMathExpression[i + 1]);
                }
            }
            return true;
        }


        private bool CheckTwoOperators(char first, char second)
        {
            if ((first.Equals('*') || first.Equals('/')) && (second.Equals('+') || second.Equals('-'))) {
                return true;
            }
            if ((first.Equals('+') || first.Equals('-') ||  first.Equals('^')) && (second.Equals('+') || second.Equals('-'))) {
                return true;
            }
            return false;
        }

        private bool IsOperator(char findOPerator)
        {
            return (findOPerator.Equals('*') || findOPerator.Equals('/') || findOPerator.Equals('-') || findOPerator.Equals('+') ||  findOPerator.Equals('^'));
        }
    }
}
