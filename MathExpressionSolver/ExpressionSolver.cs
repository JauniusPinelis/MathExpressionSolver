using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathExpressionSolver
{
    public class ExpressionSolver
    {
        #region Private Methods

        private double Evaluate(double number1, char op, double number2)
        {
            switch (op)
            {
                case '*':
                    return number1 * number2;
                case '/':
                    return number1 / number2;
                case '+':
                    return number1 + number2;
                case '-':
                    return number1 - number2;
                default:
                    throw new Exception();
            }
        }

        private double EvaluateStacks(Stack<double> numberStack, Stack<char> operatorStack)
        {

            while (operatorStack.Count > 0)
            {
                var number2 = numberStack.Pop();
                var number1 = numberStack.Pop();

                var op = operatorStack.Pop();

                numberStack.Push(Evaluate(number1, op, number2));
            }

            return numberStack.Pop();
        }

        private static int GetPredecence(char ch)
        {
            switch (ch)
            {
                case '*':
                    return 2;
                case '/':
                    return 2;
                case '+':
                    return 1;
                case '-':
                    return 1;
                default:
                    return 0;
            }
        }

        #endregion


        /// <summary>
        /// Employs a Shunting-yards algortihm to parse expression into
        /// 2 stacks (numeric values and arthmetic operators)
        /// </summary>
        /// <returns></returns>
        public double CalculateExpressionResult(string expression)
        {
            var numberStack = new Stack<double>();
            var operatorStack = new Stack<char>();

            foreach (char ch in expression)
            {
                if (Char.IsDigit(ch))
                {
                    var number2 = (int)Char.GetNumericValue(ch);

                    if (operatorStack.Count > 0 && GetPredecence(operatorStack.Peek()) == 2)
                    {
                        var number1 = numberStack.Pop();
                        var op = operatorStack.Pop();

                        numberStack.Push(Evaluate(number1, op, number2));
                    }
                    else
                    {
                        numberStack.Push((int)Char.GetNumericValue(ch));
                    }
                }
                else
                {
                    operatorStack.Push(ch);
                }
            }
            return EvaluateStacks(numberStack, operatorStack);
        }
    }
}
