using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathExpressionSolver
{
    public class ConsoleClient
    {
        readonly ExpressionSolver solver;

        public bool IsRunning { get; set; }
        public bool IsError { get; set; }

        public string Expression { get; set; }

        public ConsoleClient()
        {
            solver = new ExpressionSolver();
            IsRunning = true;
            IsError = false;
        }

        public void RequestInput()
        {
            Console.WriteLine("Please enter a Mathematical expression or Exit to close the program:\n");
            Console.Write("Expression= ");
            Expression = Console.ReadLine();

            IsError = !ValidateExpression();
        }

        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Expression Parsing portal!\n");
        }

        public void DisplayErrorMessage()
        {
            Console.WriteLine("The expression you entered could not be parsed. Please try again.\n");
        }

        public void DisplayExitMessage()
        {
            Console.WriteLine("\n Thank you for using my expression solver!\n I hope it passes your tests and requirements :)\n Press any key to close the program");
            Console.ReadLine();
        }

        public string FormatExpression(string expr)
        {
            return expr.Replace(" ", string.Empty);
        }

        public void ExitApplication()
        {
            IsRunning = false;
        }
        /// <summary>
        /// Checks if an 'exit' command has been entered
        /// </summary>
        public bool RequestExit()
        {
            return Expression.ToLower() == "exit";
        }

        /// <summary>
        /// Makes a check the the expression entered by the user is valid
        /// Check if there are any alphabet characters in the the expressions, if it does returns False. Otherwise return True
        /// </summary>>
        public bool ValidateExpression()
        {
            if (!Regex.IsMatch(Expression, @"[a-zA-Z]"))
                return true;
            return false;
        }

        public void DisplayExpressionResult()
        {
            Console.WriteLine("Result = {0} \n", getExpressionResult());
        }

        public double getExpressionResult()
        {
            var test = solver.CalculateExpressionResult(Expression);
            return test;
        }
    }
}
