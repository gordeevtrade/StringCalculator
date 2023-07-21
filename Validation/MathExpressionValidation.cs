using System.Globalization;

namespace Validation
{
    public class MathExpressionValidation
    {
        private NumberValidation _numberValidation;
        private ParenthesisValidation _parenthesesValidation;
        private OperatorsValidation _operationValidation;

        public MathExpressionValidation()
        {
            _numberValidation = new NumberValidation();
            _parenthesesValidation = new ParenthesisValidation();
            _operationValidation = new OperatorsValidation();
        }

        public bool IsMathExpressionValid(string inputMathExpression)
        {
            bool isValid = false;

            bool emptyLine = EmptyStringChecker(inputMathExpression);

            if (!emptyLine)
            {
                bool numbers = _numberValidation.IsCorrectNumber(inputMathExpression);
                bool parenthesis = _parenthesesValidation.IsCorrectParenthesis(inputMathExpression);
                bool operators = _operationValidation.IsCorrectOperators(inputMathExpression);

                if (numbers && parenthesis && operators)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        private bool EmptyStringChecker(string mathExpressions)
        {
            if (string.IsNullOrWhiteSpace(mathExpressions))
            {
                return true;
            }
            return false;
        }

    }
}
