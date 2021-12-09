using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Math
{
    public class Tokenizer
    {
        private bool IsNumber(char c)
        {
            return c >= '0' && c <= '9';
        }

        private bool IsEmpty(char c)
        {
            return (c == ' ' || c == '\t' || c == '\f' || c == '\r' || c == '\n');
        }

        public List<Token> Tokenize(string Source)
        {
            var tokens = new List<Token>();
            
            for (var position = 0; position < Source.Length; ++position)
            {
                var c = Source[position];

                if (IsEmpty(c))
                    continue;

                if (IsNumber(c))
                {
                    var output = "";

                    for (var i = position; i < Source.Length; ++i)
                    {
                        if (IsNumber(Source[i]))
                            output += Source[i];
                        else
                            break;
                    }

                    position += output.Length - 1;

                    tokens.Add(new Token(TokenType.NUM, output, 0, position));
                }

                else if (c == '+' || c == '-')
                    tokens.Add(new Token(TokenType.OP, Source[position].ToString(), 2, position));

                else if (c == '*' || c == '/')
                    tokens.Add(new Token(TokenType.OP, Source[position].ToString(), 3, position));

                else if (c == '(')
                    tokens.Add(new Token(TokenType.OPEN, Source[position].ToString(), 0, position));

                else if (c == ')')
                    tokens.Add(new Token(TokenType.CLOSE, Source[position].ToString(), 0, position));
            }

            return tokens;
        }
    }
}