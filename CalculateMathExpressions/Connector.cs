using System.Globalization;

namespace CalculateMathExpressions
{
    public class Connector
    {
        public char DecimalSeparator { get; set; }
        public char ThousandSeparator { get; set; }

        private CultureInfo _curentCulture;

        public Connector()
        {
            _curentCulture = CultureInfo.CurrentUICulture;
            SetNumbersConfiguration();
        }

        public Connector(CultureInfo newCulture)
        {
            _curentCulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;
            SetNumbersConfiguration();
        }

        private void SetNumbersConfiguration()
        {
            DecimalSeparator = _curentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            ThousandSeparator = _curentCulture.NumberFormat.NumberGroupSeparator.ToCharArray()[0];
        }
    }
}