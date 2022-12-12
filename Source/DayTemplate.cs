using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class DayX : IDay
    {
        public string Identifier => "dayX";
        private string[] _input = Array.Empty<string>();

        public void ProcessExample()
        {
            var input = @"

            ".Split(Environment.NewLine);

            PopulateData(input);

            int result = ParseFirst();
            int result2 = ParseSecond();

            Assert.AreEqual(0, result);
            Assert.AreEqual(0, result2);
        }

        private int ParseFirst()
        {
            int result = 0;


            return result;
        }

        private int ParseSecond()
        {
            int result = 0;


            return result;
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;
        }

        public void ProcessFirst()
        {
            int result = ParseFirst();

            Console.WriteLine($"{Identifier}.1 result is {result} ");
            Assert.AreEqual(0, result);
        }

        public void ProcessSecond()
        {
            int result = ParseSecond();

            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(0, result);
        }
    }
}