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

            Assert.AreEqual(7, ParseFirst(input[0]));
            Assert.AreEqual(5, ParseFirst(input[1]));
            Assert.AreEqual(6, ParseFirst(input[2]));
            Assert.AreEqual(10, ParseFirst(input[3]));
            Assert.AreEqual(11, ParseFirst(input[4]));

            Assert.AreEqual(19, ParseSecond(input[0]));
            Assert.AreEqual(23, ParseSecond(input[1]));
            Assert.AreEqual(23, ParseSecond(input[2]));
            Assert.AreEqual(29, ParseSecond(input[3]));
            Assert.AreEqual(26, ParseSecond(input[4]));
        }

        private int ParseFirst(string line)
        {
            const int NumRange = 4;

            for (int i = 0; i + NumRange < line.Length; i++)
            {
                var span = line[i..(i + NumRange)];
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
                    return i + NumRange;
                }
            }

            throw new Exception();
        }

        private int ParseSecond(string line)
        {
            const int NumRange = 14;

            for (int i = 0; i + NumRange < line.Length; i++)
            {
                var span = line[i..(i + NumRange)];
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
                    return i + NumRange;
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
                result += ParseFirst(line);
            }

            Console.WriteLine($"{Identifier}.1 result is {result} ");
            Assert.AreEqual(1965, result);
        }

        public void ProcessSecond()
        {
            int result = 0;

            foreach (var line in _input)
            {
                result += ParseSecond(line);
            }

            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(2773, result);
        }
    }
}