using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day2 : IDay
    {
        private string[] _input = Array.Empty<string>();

        public string Identifier => "day2";

        const int Loss = 0;
        const int Draw = 3;
        const int Win = 6;

        private enum Action
        {
            Rock = 1, // 1 for rock
            Paper = 2, // 2 for paper
            Scissors = 3 // 3 for scissor
        }

        private Action ParseAction(char c)
        {
            switch (c)
            {
                case 'A':
                case 'X':
                    return Action.Rock;
                case 'B':
                case 'Y':
                    return Action.Paper;
                case 'C':
                case 'Z':
                    return Action.Scissors;
                default:
                    throw new Exception();
            }
        }

        public int ParseRound(string data)
        {
            if (data.Length != 3) throw new Exception();

            var target = ParseAction(data[0]);
            var our = ParseAction(data[2]);
            int points = (int)our;

            switch (our)
            {
                case Action.Paper:
                    if (target == Action.Paper) points += Draw;
                    if (target == Action.Rock) points += Win;
                    if (target == Action.Scissors) points += Loss;
                    break;
                case Action.Rock:
                    if (target == Action.Paper) points += Loss;
                    if (target == Action.Rock) points += Draw;
                    if (target == Action.Scissors) points += Win;
                    break;
                case Action.Scissors:
                    if (target == Action.Paper) points += Win;
                    if (target == Action.Rock) points += Loss;
                    if (target == Action.Scissors) points += Draw;
                    break;
            }

            return points;
        }


        public int ParseRoundSecond(string data)
        {
            if (data.Length != 3) throw new Exception();

            var target = ParseAction(data[0]);
            var wantedOutcome = data[2];

            int points = 0;

            switch (wantedOutcome)
            {
                case 'X':
                    points += Loss;
                    if (target == Action.Paper) points += (int)Action.Rock;
                    if (target == Action.Rock) points += (int)Action.Scissors;
                    if (target == Action.Scissors) points += (int)Action.Paper;
                    break;
                case 'Y':
                    points += Draw;
                    points += (int)target;
                    break;
                case 'Z':
                    points += Win;
                    if (target == Action.Paper) points += (int)Action.Scissors;
                    if (target == Action.Rock) points += (int)Action.Paper;
                    if (target == Action.Scissors) points += (int)Action.Rock;
                    break;
            }

            return points;
        }

        public void ProcessExample()
        {
            var example = @"A Y
B X
C Z".Split(Environment.NewLine);

            int result = 0;
            int result2 = 0;

            foreach (var line in example)
            {
                result += ParseRound(line);
            }

            foreach (var line in example)
            {
                result2 += ParseRoundSecond(line);
            }

            Assert.AreEqual(15, result);
            Assert.AreEqual(12, result2);
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
                result += ParseRound(line);
            }

            Console.WriteLine($"{Identifier}.1 : result was {result}");
            Assert.AreEqual(14531, result);
        }

        public void ProcessSecond()
        {
            int result = 0;
            foreach (var line in _input)
            {
                result += ParseRoundSecond(line);
            }

            Console.WriteLine($"{Identifier}.2 : result was {result}");
            Assert.AreEqual(11258, result);
        }
    }
}