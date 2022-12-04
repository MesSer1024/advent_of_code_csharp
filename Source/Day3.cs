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

        public void ProcessExample()
        {
            var example = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".Split(Environment.NewLine);
            int result = 0;

            foreach(var line in example)
            {
                result += ParseRucksack(line);
            }

            Assert.AreEqual(157, result);
        }

        public void ProcessFirst(string[] input)
        {
            throw new NotImplementedException();
        }

        public void ProcessSecond(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}