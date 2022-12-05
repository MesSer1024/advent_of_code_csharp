using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day5 : IDay
    {
        public string Identifier => "day5";
        private string[] _input = Array.Empty<string>();
        private int _firstCommandLine = 0;
        private Layout _layout = new Layout(9);

        public void ProcessExample()
        {
            var input = @"    [D]
[N] [C]
[Z] [M] [P]
 1   2   3

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2".Split(Environment.NewLine);

            PopulateData(input);

            MoveAccordingToCommands();
            var result = ReadCrates();

            // second
            PopulateData(input);

            MoveAccordingToCommandsSecond();
            var result2 = ReadCrates();

            Assert.AreEqual("CMZ", result);
            Assert.AreEqual("MCD", result2);
        }

        private string ReadCrates()
        {
            string result = "";
            foreach (var stack in _layout.Stacks)
            {
                result += stack.Last();
            }

            return result;
        }

        class Layout
        {
            public List<char>[] Stacks;

            public Layout(int num)
            {
                if (num == 3)
                {
                    Stacks = new List<char>[3];
                }
                else
                {
                    Stacks = new List<char>[9];
                }

                for (int i = 0; i < Stacks.Length; ++i)
                {
                    Stacks[i] = new List<char>();
                }

            }
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;
            int rowIdx = 0;

            while (true)
            {
                var line = lines[rowIdx++];
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }
            }

            _firstCommandLine = rowIdx;
            if (lines.Length > 15)
            {
                _layout = new Layout(9);
            }
            else
            {
                _layout = new Layout(3);
            }

            rowIdx -= 3;
            for (int i = rowIdx - 1; rowIdx >= 0; rowIdx--)
            {
                var line = _input[rowIdx];

                for (int j = 0; j < _layout.Stacks.Length; j++)
                {
                    var begin = j * 4;
                    var end = j * 4 + 3;
                    if (end > line.Length)
                    {
                        break;
                    }

                    var part = line[begin..end];

                    if (!string.IsNullOrWhiteSpace(part))
                    {
                        var stack = _layout.Stacks[j];
                        var c = part[1];
                        stack.Add(c);
                    }
                }
            }
        }

        private void MoveAccordingToCommands()
        {
            foreach (var line in _input[_firstCommandLine..])
            {
                var parts = line.Split(' ');
                var num = int.Parse(parts[1]);
                var src = int.Parse(parts[3]) - 1;
                var dest = int.Parse(parts[5]) - 1;

                var input = _layout.Stacks[src];
                var target = _layout.Stacks[dest];

                target.AddRange(input.TakeLast(num).Reverse());
                input.RemoveRange(input.Count - num, num);
            }
        }

        private void MoveAccordingToCommandsSecond()
        {
            foreach (var line in _input[_firstCommandLine..])
            {
                var parts = line.Split(' ');
                var num = int.Parse(parts[1]);
                var src = int.Parse(parts[3]) - 1;
                var dest = int.Parse(parts[5]) - 1;

                var input = _layout.Stacks[src];
                var target = _layout.Stacks[dest];

                target.AddRange(input.TakeLast(num));
                input.RemoveRange(input.Count - num, num);
            }
        }

        public void ProcessFirst()
        {
            PopulateData(_input);

            MoveAccordingToCommands();
            var result = ReadCrates();

            Console.WriteLine($"{Identifier} result is {result} ");
            Assert.AreEqual("WCZTHTMPS", result);
        }

        public void ProcessSecond()
        {
            PopulateData(_input);

            MoveAccordingToCommandsSecond();
            var result = ReadCrates();

            Console.WriteLine($"{Identifier} result is {result} ");
            Assert.AreEqual("BLSGJSDTS", result);
        }
    }
}