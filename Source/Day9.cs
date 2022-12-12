using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day9 : IDay
    {
        public string Identifier => "day9";
        private string[] _input = Array.Empty<string>();

        public void ProcessExample()
        {
            var input = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2".Split(Environment.NewLine);

            PopulateData(input);

            int result = ParseFirst();
            int result2 = ParseSecond();

            Assert.AreEqual(13, result);
            Assert.AreEqual(0, result2);
        }

        private int MathDiff(int a, int b)
        {
            int diff = (a > b) ? (a - b) : (b - a);
            return diff;
        }

        private int ParseFirst()
        {
            int result = 0;

            int headX = 0;
            int headY = 0;

            int tailX = 0;
            int tailY = 0;

            List<int> positions = new();
            void RecordBoardTailPos()
            {
                int key = tailY << 16 | tailX;
                positions.Add(key);
            }

            void moveHeadX(int x)
            {
                headX += x;

                if (MathDiff(headX, tailX) >= 2)
                {
                    tailX += x;

                    if (tailY != headY)
                    {
                        tailY = headY;
                    }
                }
            }

            void moveHeadY(int y)
            {
                headY += y;
                if (MathDiff(headY, tailY) >= 2)
                {
                    tailY += y;

                    if (tailX != headX)
                    {
                        tailX = headX;
                    }
                }
            }

            void RecordBoard(int index, char dir, int len)
            {
                var sb = new System.Text.StringBuilder();
                if(index == 0)
                {
                    sb.AppendLine(dir.ToString() + " " + len);
                }

                RecordBoardTailPos();

                int MaxColumn = 120;
                int MaxRow = 120;

                for (int j = 0; j < MaxRow; j++)
                {
                    var y = j - MaxRow / 2;

                    for (int i = 0; i < MaxColumn; i++)
                    {
                        var x = i - MaxColumn / 2;
                        if (x == headX && y == headY)
                        {
                            sb.Append('H');
                        }
                        else if (x == tailX && y == tailY)
                        {
                            sb.Append('T');
                        }
                        else
                        {
                            sb.Append('.');
                        }
                    }
                    sb.AppendLine();
                }

                Console.Write(sb.ToString());
            }

            foreach (var line in _input)
            {
                var dir = line[0];
                var len = line[2] - '0';

                switch (dir)
                {
                    case 'R':
                        for (int i = 0; i < len; i++)
                        {
                            moveHeadX(1);
                            RecordBoard(i, dir, len);
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < len; i++)
                        {
                            moveHeadX(-1);
                            RecordBoard(i, dir, len);
                        }
                        break;
                    case 'U':
                        for (int i = 0; i < len; i++)
                        {
                            moveHeadY(-1);
                            RecordBoard(i, dir, len);
                        }

                        break;
                    case 'D':
                        for (int i = 0; i < len; i++)
                        {
                            moveHeadY(1);
                            RecordBoard(i, dir, len);
                        }
                        break;
                }

            }

            var unique = positions.Distinct().ToList();
            return unique.Count;
        }

        private int ParseSecond()
        {
            int result = 0;


            return result;
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;
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