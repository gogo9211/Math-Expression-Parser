using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Math
{
    public class Parser
    {
        public List<Token> Parse(List<Token> Tokens)
        {
            var queue = new List<Token>();
            var stack = new Stack<Token>();

            for (var i = 0; i < Tokens.Count; ++i)
            {
                var firstToken = Tokens[i];

                if (firstToken.Type == TokenType.NUM)
                    queue.Add(Tokens[i]);

                else if (firstToken.Type == TokenType.OP)
                {
                    while (stack.Count > 0 && stack.Peek().Type == TokenType.OP)
                    {
                        var secondToken = stack.Peek();

                        if (firstToken.Precedence <= secondToken.Precedence)
                        {
                            queue.Add(secondToken);

                            stack.Pop();
                        }
                        else
                            break;
                    }

                    stack.Push(firstToken);
                }

                else if (firstToken.Type == TokenType.OPEN)
                    stack.Push(firstToken);

                else if (firstToken.Type == TokenType.CLOSE)
                {
                    while (stack.Count > 0 && stack.Peek().Type != TokenType.OPEN)
                        queue.Add(stack.Pop());

                    stack.Pop();
                }
            }

            while (stack.Count > 0)
                queue.Add(stack.Pop());

            return queue;
        }
    }
}