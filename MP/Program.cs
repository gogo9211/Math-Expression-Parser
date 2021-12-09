using MP.Math;
using System;

namespace MP
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var tokenizer = new Tokenizer();
                var parser = new Parser();
                var eval = new Evaluate();

                var input = Console.ReadLine();

                var tokens = tokenizer.Tokenize(input);
                var parsed = parser.Parse(tokens);
                var result = eval.Calculate(parsed);

                Console.WriteLine("Output: {0}", result);
            }
        }
    }
}