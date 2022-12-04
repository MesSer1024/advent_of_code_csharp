using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public interface IDay
    {
        string Identifier { get; }
        bool SameData { get; }

        void ProcessExample();
        void ProcessFirst(string[] input);
        void ProcessSecond(string[] input);
    }

    public class Day1 : IDay
    {
        public string Identifier { get { return "day1";}}
        public bool SameData { get { return true;} }

        private class Elf : IComparable<Elf>
        {
            public int Calories;

            public int CompareTo(Elf? other)
            {
                return Calories > other?.Calories ? -1 : 1;
            }
        }


        private string[] _inputPart1 = Array.Empty<string>();
        List<Elf> _elves = new List<Elf>();

        private void PopulateElves(string[] input)
        {
            _elves.Clear();
            _elves.Add(new Elf());

            foreach(var line in input)
            {
                if(String.IsNullOrEmpty(line))
                {
                    _elves.Add(new Elf());
                    continue;
                }

                var idx = _elves.Count -1;
                _elves[idx].Calories += int.Parse(line);
            }

            _elves.Sort();
        }

        private Elf FindBestElf()
        {
            return _elves[0];
        }

        private Tuple<Elf, Elf, Elf> Find3BestElves()
        {

            return new Tuple<Elf, Elf, Elf>(_elves[0], _elves[1], _elves[2]);
        }

        public void ProcessExample()
        {
        string[] example = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000".Split(Environment.NewLine);

            PopulateElves(example);
            var best = FindBestElf();

            Assert.AreEqual(5, _elves.Count);
            Assert.AreEqual(best.Calories, 24000);
        }

        public void ProcessFirst(string[] input)
        {
            _inputPart1 = input;
            PopulateElves(input);

            var best = FindBestElf();

            Console.WriteLine($"Day1_a: Calories = {best.Calories}");
            Assert.AreEqual(69310, best.Calories);
        }

        public void ProcessSecond(string[] input)
        {
            var (a,b,c) = Find3BestElves();

            int calories = a.Calories + b.Calories + c.Calories;

            Console.WriteLine($"Day1_b: Calories = {calories}");
            Assert.AreEqual(206104, calories);
        }
    }
}