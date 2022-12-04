using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day3 : IDay
    {
        private string[] _input = Array.Empty<string>();

        public string Identifier => "day3";

        private int ParseFirst(string input)
        {
            var half = input.Length/2;
            var first = input.AsSpan()[..half];
            var second = input.AsSpan()[half..];

            int value = 0;

            foreach(var c in first)
            {
                if(second.Contains(c))
                {
                    if(c >= 'a' && c <= 'z')
                    {
                        value += (c - 'a') + 1;
                    }
                    else
                    {
                        value += (c - 'A') + 27;
                    }
                    return value;
                }
            }

            return value;
        }

        private int ParseSecond(Span<string> members)
        {
            var member1 = members[0];
            var member2 = members[1];
            var member3 = members[2];

            int value = 0;

            foreach(var c in member1)
            {
                if(member2.Contains(c) && member3.Contains(c))
                {
                    if(c >= 'a' && c <= 'z')
                    {
                        value += (c - 'a') + 1;
                    }
                    else
                    {
                        value += (c - 'A') + 27;
                    }
                    return value;
                }
            }

            throw new Exception();
        }

        public void ProcessExample()
        {
            var input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".Split(Environment.NewLine);
            int result = 0;
            int result2 = 0;

            foreach(var line in input)
            {
                result += ParseFirst(line);
            }

            for(int i=0; i < input.Length; i+=3)
            {
                result2 += ParseSecond(input[i..(i+3)]);
            }


            Assert.AreEqual(157, result);
            Assert.AreEqual(70, result2);
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
            Assert.AreEqual(7817, result);
        }

        public void ProcessSecond()
        {
            int result = 0;

            for(int i=0; i < _input.Length; i+=3)
            {
                result += ParseSecond(_input[i..(i+3)]);
            }

            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(2444, result);
        }
    }
}