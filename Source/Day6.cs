using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day6 : IDay
    {
        public string Identifier => "day6";
        private string[] _input = Array.Empty<string>();

        public void ProcessExample()
        {
            var input = @"

            ".Split(Environment.NewLine);

            int result = 0;
            int result2 = 0;

            foreach(var line in input)
            {
                result += ParseFirst(line);
            }

            foreach(var line in input)
            {
                result2 += ParseSecond(line);
            }

            Assert.AreEqual(0, result);
            Assert.AreEqual(0, result2);
        }

        private int ParseFirst(string line)
        {
            return 0;
        }

        private int ParseSecond(string line)
        {
            return 0;
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;
        }

        public void ProcessFirst()
        {
            int result = 0;

            foreach(var line in _input)
            {
                result += ParseFirst(line);
            }

            Console.WriteLine($"{Identifier}.1 result is {result} ");
            Assert.AreEqual(0, result);
        }

        public void ProcessSecond()
        {
            int result = 0;

            foreach(var line in _input)
            {
                result += ParseSecond(line);
            }

            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(0, result);
        }
    }
}