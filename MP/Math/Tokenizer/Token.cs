using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Math
{
    public class Token
    {
        public string Text { get; set; }

        public int Position { get; set; }

        public int Precedence { get; set; }

        public TokenType Type { get; set; }

        public Token(TokenType type, string text, int precedence, int position)
        {
            Type = type;
            Text = text;
            Position = position;
            Precedence = precedence;
        }

        public override string ToString()
        {
            return String.Format("Token: {0} | Type: {1} | Precedence: {2} | Position: {3}", Text, Type.ToString(), Precedence, Position);
        }
    }
}