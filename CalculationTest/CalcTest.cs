
using CalculateMathExpressions;
using FileReader;
using System.Globalization;
using Validation;

namespace CalculationTest
{
    [TestClass]
    public class CalcTest
    {

        [DataTestMethod]
        [DataRow("2---2")]
        [DataRow("2-+/2")]
        [DataRow("1+a")]
        [DataRow("2-(/2+2)")]
        [DataRow("2+2+(5-5))")]
        [DataRow("2+5-")]
        [DataRow("2+50-6*")]
        [DataRow("/2+50-6")]
        [DataRow("*2.5+50-6")]
        [DataRow("2.5+(*50-6)")]
        [DataRow(")1+1(")]
        [DataRow("1 1 + 1 1")]
        [DataRow("2+*2")]
        public void TestWrongMathExpression(string income)
        {
            CultureInfo newCulture = new CultureInfo("en-US");
            newCulture.NumberFormat.NumberDecimalSeparator = ".";
            newCulture.NumberFormat.NumberGroupSeparator = "-";
            Connector _connector = new Connector(newCulture);
            MathExpressionValidation validation = new MathExpressionValidation();
            bool validLine = validation.IsMathExpressionValid(income);
            Assert.IsFalse(validLine);
        }

        [DataTestMethod]
        [DataRow("-2--2")]
        [DataRow("5.2+5*5-6")]
        [DataRow("1+(5.2-10)-(5+5)")]
        [DataRow("2-(2+2*2/3)")]
        [DataRow("5*(5-5)-5")]
        [DataRow("20/6")]
        [DataRow("55.6-20.6")]
        [DataRow("555-200+(300/2)")]
        [DataRow("(-((-2)--2))+3")]
        [DataRow("3*+2")]
        [DataRow("3*-2")]
        [DataRow(" 555 - 200 + (  300 /  2  ) ")]
        public void TestCorrectMathExpression(string income)
        {
            CultureInfo newCulture = new CultureInfo("en-US");
            newCulture.NumberFormat.NumberDecimalSeparator = ".";
            Connector _connector = new Connector(newCulture);
            MathExpressionValidation validation = new MathExpressionValidation();
            bool validLine = validation.IsMathExpressionValid(income);
            Assert.IsTrue(validLine);
        }


        [DataTestMethod]
        [DataRow("5-(5*5)", "-20")]
        [DataRow("-2--4", "2")]
        [DataRow("10/5*(5-5)", "0")]
        [DataRow("(5+5)+(5*5)", "35")]
        [DataRow("5/(5-5)", "divide by zero")]
        [DataRow("5.2+5.5", "10.7")]
        [DataRow("5.5+10-5*2+(2.3+5.4)", "13.2")]
        [DataRow("(-((-2)--2))+3", "3")]
        [DataRow("2*+2", "4")]
        [DataRow("+2++2", "4")]
        public void TestCalculation(string income, string expected)
        {

            CultureInfo newCulture = new CultureInfo("en-US");
            newCulture.NumberFormat.NumberDecimalSeparator = ".";
            Connector _connector = new Connector(newCulture);

            ReversePolishNotation reversePolishNotation = new ReversePolishNotation(_connector);
            CalculateExpressions calculateExpression = new CalculateExpressions(_connector);
            var results = reversePolishNotation.PosfixForm(income);
            string actual = calculateExpression.CalculateExpression(results);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("5^2", "25")]
        [DataRow("-2^-2", "-0.25")]
        [DataRow("5+(2^5)", "37")]
        [DataRow("2^(2+1)", "8")]
        [DataRow("(3+2)^2", "25")]
        [DataRow("2^2^2^2", "256")]

        public void TestCalculationDegree(string income, string expected)
        {
            CultureInfo newCulture = new CultureInfo("en-US");
            newCulture.NumberFormat.NumberDecimalSeparator = ".";
            Connector _connector = new Connector(newCulture);
            ReversePolishNotation reversePolishNotation = new ReversePolishNotation(_connector);
            CalculateExpressions calculateExpression = new CalculateExpressions(_connector);
            var results = reversePolishNotation.PosfixForm(income);
            string actual = calculateExpression.CalculateExpression(results);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("5+5", "5 5 +")]
        [DataRow("-2--2", "2 ~2 ~-")]
        [DataRow("-2--4", "2 ~4 ~-")]
        [DataRow("(5+5)-(6*6)", "5 5 +6 6 *-")]
        [DataRow("5*2+3*5-3", "5 2 *3 5 *+3 -")]
        [DataRow("5+(5-2)-2+7*(5+1)", "5 5 2 -+2 -7 5 1 +*+")]
        public void TestReversePolishNOtation(string income, string expected)
        {
            Connector _connector = new Connector();
            ReversePolishNotation reversePolishNotation = new ReversePolishNotation(_connector);
            var results = reversePolishNotation.PosfixForm(income);
            string actual = results;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodForMissingFile()
        {
            var fileReader = new ReadingFile();
            var linesFromFileReader = fileReader.IsFileExist("good.txt");
            Assert.IsFalse(linesFromFileReader);
        }
    }
}
