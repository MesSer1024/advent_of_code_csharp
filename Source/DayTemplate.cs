using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class DayTemplate : IDay
    {
        public string Identifier => "day5";

        public bool SameData => true;

        private int ParseFirst(string line)
        {
            return 0;
        }

        private int ParseSecond(string line)
        {
            return 0;
        }

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

        public void ProcessFirst(string[] input)
        {
            int result = 0;

            foreach(var line in input)
            {
                result += ParseFirst(line);
            }

            Console.WriteLine($"{Identifier} result is {result} ");
            Assert.AreEqual(0, result);
        }

        public void ProcessSecond(string[] input)
        {

            int result = 0;

            foreach(var line in input)
            {
                result += ParseSecond(line);
            }

            Console.WriteLine($"{Identifier} result is {result} ");
            Assert.AreEqual(0, result);
        }
    }
}