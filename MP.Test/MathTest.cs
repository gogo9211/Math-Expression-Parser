using System;
using Xunit;
using MP.Math;

namespace MP.Test
{
    public class MathTest
    {
        [Fact]
        public void Problem0()
        {
            const string input = "5 + 50 * 2 - 5";

            var tokenizer = new Tokenizer();
            var parser = new Parser();
            var eval = new Evaluate();

            var tokens = tokenizer.Tokenize(input);
            var parsed = parser.Parse(tokens);
            var result = eval.Calculate(parsed);

            Assert.Equal(100, result);
        }

        [Fact]
        public void Problem1()
        {
            const string input = "(10 * 10) / (1 + 1) + 5";

            var tokenizer = new Tokenizer();
            var parser = new Parser();
            var eval = new Evaluate();

            var tokens = tokenizer.Tokenize(input);
            var parsed = parser.Parse(tokens);
            var result = eval.Calculate(parsed);

            Assert.Equal(55, result);
        }
    }
}