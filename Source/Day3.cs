using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day3 : IDay
    {
        public string Identifier => "day3";

        public bool SameData => true;

        private int ParseRucksack(string input)
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

        private int ParseRucksackSecond(Span<string> members)
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
                result += ParseRucksack(line);
            }

            for(int i=0; i < input.Length; i+=3)
            {
                result2 += ParseRucksackSecond(input[i..(i+3)]);
            }


            Assert.AreEqual(157, result);
            Assert.AreEqual(70, result2);
        }

        public void ProcessFirst(string[] input)
        {
            int result = 0;

            foreach(var line in input)
            {
                result += ParseRucksack(line);
            }

            Console.WriteLine($"{Identifier} result is {result} ");
            Assert.AreEqual(7817, result);
        }

        public void ProcessSecond(string[] input)
        {

            int result = 0;

            for(int i=0; i < input.Length; i+=3)
            {
                result += ParseRucksackSecond(input[i..(i+3)]);
            }

            Console.WriteLine($"{Identifier} result is {result} ");
            Assert.AreEqual(2444, result);
        }
    }
}