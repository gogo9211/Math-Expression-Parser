using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Math
{
    public class Evaluate
    {
        public double Calculate(List<Token> tokens)
        {
            var stack = new Stack<double>();

            foreach (var token in tokens)
            {
                if (token.Type == TokenType.NUM)
                    stack.Push(double.Parse(token.Text));

                else if (token.Type == TokenType.OP)
                {
                    if (token.Text == "+")
                    {
                        var firstValue = stack.Pop();
                        var secondValue = stack.Pop();

                        stack.Push(firstValue + secondValue);
                    }

                    else if (token.Text == "-")
                    {
                        var firstValue = stack.Pop();
                        var secondValue = stack.Pop();

                        stack.Push(secondValue - firstValue);
                    }

                    else if (token.Text == "*")
                    {
                        var firstValue = stack.Pop();
                        var secondValue = stack.Pop();

                        stack.Push(secondValue * firstValue);
                    }

                    else if (token.Text == "/")
                    {
                        var firstValue = stack.Pop();
                        var secondValue = stack.Pop();

                        stack.Push(secondValue / firstValue);
                    }
                }
            }

            if (stack.Count == 1)
                return stack.Pop();

            return 0;
        }
    }
}