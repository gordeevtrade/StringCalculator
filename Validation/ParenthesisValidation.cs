namespace Validation
{
    public class ParenthesisValidation
    {
        public bool IsCorrectParenthesis(string inputMathExpression)
        {
            int numberOfParenthesis = 0;

            for (int i = 0; i < inputMathExpression.Length; i++)
            {
                if (inputMathExpression[i].Equals('(') && inputMathExpression[i + 1].Equals(')'))
                {
                    return false;
                }

                if (inputMathExpression[i].Equals('(') && ReturnOperator(inputMathExpression[i + 1]) && inputMathExpression[i + 2].Equals(')'))
                {
                    return false;
                }


                if ((inputMathExpression[i].Equals('(') && i != 0) && char.IsNumber(inputMathExpression[i - 1]))
                {
                    return false;
                }

                if ((inputMathExpression[i].Equals(')') && i != inputMathExpression.Length - 1) && char.IsNumber(inputMathExpression[i + 1]))
                {
                    return false;
                }


                if (inputMathExpression[i].Equals('('))
                {
                    numberOfParenthesis++;
                }
                if (inputMathExpression[i].Equals(')'))
                {
                    numberOfParenthesis--;
                }
            }

            if (numberOfParenthesis == 0)
            {
                return true;
            }
            return false;
        }

        public bool ReturnOperator(char findOPerator)
        {
            return (findOPerator.Equals('*') || findOPerator.Equals('/') || findOPerator.Equals('-') || findOPerator.Equals('+'));
        }

    }
}
