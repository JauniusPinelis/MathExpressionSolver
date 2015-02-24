using MathExpressionSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleClient = new ConsoleClient();

            consoleClient.DisplayWelcomeMessage();

            while (consoleClient.IsRunning)
            {
                consoleClient.RequestInput();
                if (!consoleClient.IsError)
                    consoleClient.DisplayExpressionResult();
                else if (consoleClient.RequestExit())
                    consoleClient.ExitApplication();
                else
                    consoleClient.DisplayErrorMessage();
            }
            consoleClient.DisplayExitMessage();
        }

    }
}
