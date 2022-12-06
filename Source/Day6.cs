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
            var input = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb
            bvwbjplbgvbhsrlpgdmjqwftvncz
            nppdvjthqldpwncqszvftbrmjlhg
            nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg
            zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw".Split(Environment.NewLine);

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                input[i] = line.Trim();
            }

            Assert.AreEqual(7, Parse(input[0], 4));
            Assert.AreEqual(5, Parse(input[1], 4));
            Assert.AreEqual(6, Parse(input[2], 4));
            Assert.AreEqual(10, Parse(input[3], 4));
            Assert.AreEqual(11, Parse(input[4], 4));

            Assert.AreEqual(19, Parse(input[0], 14));
            Assert.AreEqual(23, Parse(input[1], 14));
            Assert.AreEqual(23, Parse(input[2], 14));
            Assert.AreEqual(29, Parse(input[3], 14));
            Assert.AreEqual(26, Parse(input[4], 14));
        }

        private int Parse(string line, int spanSize)
        {
            for (int i = 0; i + spanSize < line.Length; i++)
            {
                var span = line[i..(i + spanSize)];
                bool isDuplicate = false;

                for (int j = 0; j < span.Length; j++)
                {
                    var begin = span[j];
                    var rest = span.Skip(j + 1);
                    if (rest.Contains(begin))
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    return i + spanSize;
                }
            }

            throw new Exception();
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;
        }

        public void ProcessFirst()
        {
            int result = 0;

            foreach (var line in _input)
            {
                result += Parse(line, 4);
            }

            Console.WriteLine($"{Identifier}.1 result is {result} ");
            Assert.AreEqual(1965, result);
        }

        public void ProcessSecond()
        {
            int result = 0;

            foreach (var line in _input)
            {
                result += Parse(line, 14);
            }

            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(2773, result);
        }
    }
}