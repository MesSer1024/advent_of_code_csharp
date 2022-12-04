using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day4 : IDay
    {
        public string Identifier => "day4";

        public bool SameData => true;

        public void ProcessExample()
        {
            var input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8".Split(Environment.NewLine);

            int result = 0;
            int result2 = 0;

            foreach(var line in input)
            {
                result += ParsePair(line);
            }

            foreach(var line in input)
            {
                result2 += ParsePairSecond(line);
            }

            Assert.AreEqual(2, result);
            Assert.AreEqual(4, result2);
        }

        private struct Foo
        {
            public int begin;
            public int end;

            public Foo(string input)
            {
                begin = int.Parse(input.Split('-')[0]);
                end = int.Parse(input.Split('-')[1]);
            }
        }

        private int ParsePair(string line)
        {
            var parts = line.Split(',');
            var first = new Foo(parts[0]);
            var second = new Foo(parts[1]);

            if(first.begin <= second.begin && first.end >= second.end)
            {
                return 1;
            }

            if(second.begin <= first.begin && second.end >= first.end)
            {
                return 1;
            }

            return 0;
        }

        private int ParsePairSecond(string line)
        {
            var parts = line.Split(',');
            var first = new Foo(parts[0]);
            var second = new Foo(parts[1]);

            var bin = first.begin;
            var bend = first.end;

            if(first.begin <= second.begin && first.end >= second.end)
            {
                return 1;
            }

            if(second.begin <= first.begin && second.end >= first.end)
            {
                return 1;
            }

            // any a in b
            if(bin >= second.begin && bin <= second.end)
            {
                return 1;
            }

            if(bend >= second.begin && bend <= second.end)
            {
                return 1;
            }


            // any b in a
            if(second.begin >= bin && second.end <= bend)
            {
                return 1;
            }

            if(second.end >= bin && second.end <= bend)
            {
                return 1;
            }

            return 0;
        }

        public void ProcessFirst(string[] input)
        {
            int result = 0;

            foreach(var line in input)
            {
                result += ParsePair(line);
            }

            Console.WriteLine($"{Identifier} result is {result} ");
            Assert.AreEqual(424, result);
        }

        public void ProcessSecond(string[] input)
        {

            int result = 0;

            foreach(var line in input)
            {
                result += ParsePairSecond(line);
            }

            Console.WriteLine($"{Identifier} result is {result} ");
            Assert.AreEqual(804, result);
        }
    }
}