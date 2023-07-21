namespace UserInterface
{
    public class InterfaceUsers
    {
        public void MissingFile()
        {
            System.Console.WriteLine("File Is Missing");
        }

        public bool StopWord(string word)
        {
            if (word == "stop") {
                return false;
            }
            return true;
        }

        public string EnterExpressionAgain()
        {
            System.Console.WriteLine("Enter stop or any words to continue");
            string word = Console.ReadLine();
            return word;
        }

        public void ShowMathExpressionResult(string maxthExpression)
        {
            System.Console.WriteLine(maxthExpression);
        }

        public string EnterMathExpression()
        {
            System.Console.WriteLine("Enter math expression");
            string usersInput = Console.ReadLine();
            return usersInput;
        }

        public string WrongInput()
        {
            string wrongInput = "Exception. Wrong input.";
            return wrongInput;
        }

        public string PrepareResultString(string element, string maxthExpression)
        {
            string preapare = element + " " + "=" + " " + maxthExpression;
            return preapare;
        }

    }
}
