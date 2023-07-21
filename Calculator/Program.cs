
using CalculateMathExpressions;
using Calculator;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        Controller controller = new Controller();

        if (args.Length == 0) {

               controller.ConsoleRunner();
        }
        else {
            string path = args[0];
            controller.FileOperations(path);
        }
    }
}
