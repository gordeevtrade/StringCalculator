namespace Validation
{
    public class NumberValidation
    {
        public bool IsCorrectNumber(string mathExpression)
        {
            List<string> arrayOfNumbers = mathExpression.Split(new Char[] { '+', '-', '/', '*', ')', '(','^' }).ToList();
            foreach (var element in arrayOfNumbers)
            {
                if (string.IsNullOrWhiteSpace(element))
                {
                    continue;
                }
                else
                {
                    bool numericElement = double.TryParse(element, out double result);
                    if (!numericElement)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
