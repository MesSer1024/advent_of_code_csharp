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

        public void ProcessExample()
        {
            var example = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".Split(Environment.NewLine);
            int result = 0;


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