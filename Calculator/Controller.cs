using CalculateMathExpressions;
using Validation;
using FileWriter;
using FileReader;
using UserInterface;

namespace Calculator
{
    public class Controller
    {
        private MathExpressionValidation _validation;
        private CalculateExpressions _calculate;
        private ReversePolishNotation _reversePolishNotation;
        private InterfaceUsers _userInterface;
        private Connector _connector;


        public Controller()
        {
            _validation = new MathExpressionValidation();
            _connector = new Connector();
            _calculate = new CalculateExpressions(_connector);
            _reversePolishNotation = new ReversePolishNotation(_connector);
            _userInterface = new InterfaceUsers();
        }

        public void FileOperations(string filePaths)
        {
            var fileLine = new ReadingFile();
            var isFileExist = fileLine.IsFileExist(filePaths);

            if (isFileExist)
            {
                var fileElements = fileLine.ReturnElementsFromFile(filePaths);
                var expressionArray = new List<string>();

                foreach (var expression in fileElements)
                {
                    if (expression == String.Empty)
                    {
                        expressionArray.Add(expression);
                        continue;
                    }
                    string maxthExpression = ReturnMathExpressionResult(expression);
                    string fullResultLine = _userInterface.PrepareResultString(expression, maxthExpression);
                    expressionArray.Add(fullResultLine);
                }
                FileWriter(filePaths, expressionArray);
            }
            else
            {
                _userInterface.MissingFile();
            }
        }

        public void ConsoleRunner()
        {
            bool checker = true;
            while (checker)
            {
                string usersInput = _userInterface.EnterMathExpression();
                string mathExpressionResult = ReturnMathExpressionResult(usersInput);
                _userInterface.ShowMathExpressionResult(mathExpressionResult);
                string stopWord = _userInterface.EnterExpressionAgain();
                checker = _userInterface.StopWord(stopWord);
            }
        }

        private string ReturnMathExpressionResult(string input)
        {
            string result = String.Empty;
            bool validExpression = _validation.IsMathExpressionValid(input);
            if (validExpression)
            {
                string mathExpression = input;
                result = CalculateExpression(mathExpression);
            }
            else
            {
                result = _userInterface.WrongInput();
            }
            return result;
        }

        private string CalculateExpression(string mathExpression)
        {
            var reversePolish = _reversePolishNotation.PosfixForm(mathExpression);
            string result = _calculate.CalculateExpression(reversePolish);
            return result;
        }

        private void FileWriter(string filePath, List<string> result)
        {
            var fileWriter = new RecordingFile();
            string newFilePath = fileWriter.CreateNewFileFullPath(filePath);
            fileWriter.CreateFile(newFilePath, result);
        }
    }
}
