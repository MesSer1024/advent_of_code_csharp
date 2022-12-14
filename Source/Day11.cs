using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day11 : IDay
    {
        public string Identifier => "day11";
        private string[] _input = Array.Empty<string>();

        List<Monkey> monkeys = new();


        public void ProcessExample()
        {
            var input = @"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1".Split(Environment.NewLine);

            PopulateData(input);

            int result = ParseFirst();
            int result2 = ParseSecond();

            Assert.AreEqual(10605, result);
            Assert.AreEqual(0, result2);
        }

        private int ParseFirst()
        {
            for (int i = 0; i < 20; ++i)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.NumInspections += monkey.Items.Count;

                    foreach (var item in monkey.Items)
                    {
                        bool OPself = monkey.Operand == " old";
                        int.TryParse(monkey.Operand, out int OPvalue);
                        int valuePostOperation = item;

                        switch (monkey.Operator)
                        {
                            case '*':
                                valuePostOperation *= (OPself ? valuePostOperation : OPvalue);
                                break;
                            case '+':
                                valuePostOperation += (OPself ? valuePostOperation : OPvalue);
                                break;
                            default:
                                throw new Exception();
                        }

                        int worry = (int)((double)valuePostOperation / 3.0f);

                        if (worry % monkey.DivisibleWith == 0)
                        {
                            monkeys[monkey.IfTrueMonkey].Items.Add(worry);
                        }
                        else
                        {
                            monkeys[monkey.IfFalseMonkey].Items.Add(worry);
                        }
                    }
                    monkey.Items.Clear();
                }

                PrintMonkeys(i);
            }

            var orderedMonkeys = monkeys.OrderByDescending(monkey => monkey.NumInspections).ToArray();


            return orderedMonkeys[0].NumInspections * orderedMonkeys[1].NumInspections;
        }

        private void PrintMonkeys(int round)
        {
            Console.WriteLine($"After Round {round}, the monkeys are holding items with these worry levels:");
            for (int i = 0; i < monkeys.Count; i++)
            {
                Monkey? monkey = monkeys[i];
                var sb = new StringBuilder();
                sb.Append($"Monkey {i}:");

                foreach (var item in monkey.Items)
                {
                    sb.Append($" {item}");
                }

                Console.WriteLine(sb.ToString());
            }
        }

        private int ParseSecond()
        {
            int result = 0;


            return result;
        }

        public class Monkey
        {
            public List<int> Items = new();
            public char Operator = ' ';
            public string Operand = "";
            public int DivisibleWith = 0;
            public int IfTrueMonkey = 0;
            public int IfFalseMonkey = 0;

            public int NumInspections = 0;
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;

            monkeys = new();
            Monkey? monkey = null;

            for (int i = 0; i < lines.Length; i++)
            {
                string? line = lines[i];
                if (string.IsNullOrEmpty(line))
                    continue;

                if (line.Contains("Monkey"))
                {
                    monkey = new Monkey();
                    monkeys.Add(monkey);

                    var items = lines[++i].Split(" items:")[1].Split(',');
                    var operation = lines[++i].Split("Operation: new = old ")[1];
                    var test = lines[++i].Split("Test: divisible by ")[1];
                    var isTrue = lines[++i].Split("If true: throw to monkey ")[1];
                    var isFalse = lines[++i].Split("If false: throw to monkey ")[1];

                    foreach (var item in items)
                    {
                        monkey.Items.Add(int.Parse(item));
                    }

                    monkey.Operator = operation[0];
                    monkey.Operand = operation[1..];

                    monkey.DivisibleWith = int.Parse(test);

                    monkey.IfTrueMonkey = int.Parse(isTrue);
                    monkey.IfFalseMonkey = int.Parse(isFalse);
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public void ProcessFirst()
        {
            int result = ParseFirst();

            Console.WriteLine($"{Identifier}.1 result is {result} ");
            Assert.AreEqual(0, result);
        }

        public void ProcessSecond()
        {
            int result = ParseSecond();

            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(0, result);
        }
    }
}