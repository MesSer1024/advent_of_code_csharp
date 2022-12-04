using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{

    public class Day1 : IDay
    {
        public string Identifier => "day1";

        private int aggregatedSum = 0;
        List<int> outputs = new();

        private int ParseFirst(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                var output = aggregatedSum;
                aggregatedSum = 0;
                return output;
            }

            aggregatedSum += int.Parse(line);
            return 0;
        }

        private int ParseSecond(string line)
        {
            return 0;
        }

        public void ProcessExample()
        {
            var input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000".Split(Environment.NewLine);

            int result = 0;
            int result2 = 0;
            List<int> outputs = new();

            foreach (var line in input)
            {
                int output = ParseFirst(line);
                if (output > 0)
                {
                    outputs.Add(output);
                }
            }
            outputs.Add(ParseFirst(""));

            outputs.Sort();

            result = outputs.Last();

            foreach(var item in outputs.TakeLast(3))
            {
                result2 += item;
            }

            Assert.AreEqual(24000, result);
            Assert.AreEqual(45000, result2);
        }

        public void PopulateData(string[] input)
        {
            foreach (var line in input)
            {
                int output = ParseFirst(line);
                if (output > 0)
                {
                    outputs.Add(output);
                }
            }
            outputs.Add(ParseFirst(""));

            outputs.Sort();
        }

        public void ProcessFirst()
        {
            int result = 0;
            result = outputs.Last();

            Console.WriteLine($"{Identifier}.1 result is {result} ");
            Assert.AreEqual(69310, result);
        }

        public void ProcessSecond()
        {
            int result = 0;
            foreach(var item in outputs.TakeLast(3))
            {
                result += item;
            }

            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(206104, result);
        }
    }
}