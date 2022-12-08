using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day8 : IDay
    {
        public string Identifier => "day8";
        private string[] _input = Array.Empty<string>();

        public void ProcessExample()
        {
            var input = @"30373
25512
65332
33549
35390".Split(Environment.NewLine);

            PopulateData(input);

            var bestResult = ParseFirst();

            var result2 = ParseSecond();

            Assert.AreEqual(21, bestResult);
            Assert.AreEqual(8, result2);
        }

        bool isVisible(int x, int y)
        {
            int numX = _input[0].Length;
            int numY = _input.Length;

            int value = _input[y][x] - '0';

            // x-axis
            {
                var row = _input[y];

                int ix;
                bool visible;

                // check right
                ix = x;
                visible = true;
                while (++ix < numX)
                {
                    int other = row[ix] - '0';

                    if(other >= value)
                    {
                        visible = false;
                        break;
                    }
                }

                if(visible)
                {
                    return true;
                }

                // check left
                ix = x;
                visible = true;
                while (--ix >= 0)
                {
                    int other = row[ix] - '0';

                    if(other >= value)
                    {
                        visible = false;
                        break;
                    }
                }

                if(visible)
                {
                    return true;
                }
            }

            // y-axis
            {
                int iy;
                bool visible;

                // check right
                iy = y;
                visible = true;
                while (++iy < numY)
                {
                    int other = _input[iy][x] - '0';

                    if(other >= value)
                    {
                        visible = false;
                        break;
                    }
                }

                if(visible)
                {
                    return true;
                }

                // check left
                iy = y;
                visible = true;
                while (--iy >= 0)
                {
                    int other = _input[iy][x]- '0';

                    if(other >= value)
                    {
                        visible = false;
                        break;
                    }
                }

                if(visible)
                {
                    return true;
                }
            }

            return false;
        }

        int countScenicScore(int x, int y)
        {
            int numX = _input[0].Length;
            int numY = _input.Length;

            int value = _input[y][x] - '0';

            int[] scores = new int[4];
            scores[0] = numX - x - 1;
            scores[1] = x;
            scores[2] = numY - y - 1;
            scores[3] = y;

            // x-axis
            {
                var row = _input[y];

                int ix;

                // check right
                ix = x;
                while (++ix < numX)
                {
                    int other = row[ix] - '0';

                    if(other >= value)
                    {
                        scores[0] = Math.Abs(ix - x);
                        break;
                    }
                }

                // check left
                ix = x;
                while (--ix >= 0)
                {
                    int other = row[ix] - '0';

                    if(other >= value)
                    {
                        scores[1] = Math.Abs(ix - x);
                        break;
                    }
                }
            }

            // y-axis
            {
                int iy;

                // check down
                iy = y;
                while (++iy < numY)
                {
                    int other = _input[iy][x] - '0';

                    if(other >= value)
                    {
                        scores[2] = Math.Abs(iy - y);
                        break;
                    }
                }

                // check up
                iy = y;
                while (--iy >= 0)
                {
                    int other = _input[iy][x]- '0';

                    if(other >= value)
                    {
                        scores[3] = Math.Abs(iy - y);
                        break;
                    }
                }
            }

            return scores[0] * scores[1] * scores[2] * scores[3];
        }

        private int ParseFirst()
        {
            int bestResult = 0;

            int numX = _input[0].Length;
            int numY = _input.Length;

            for (int y = 1; y < numY - 1; ++y)
            {
                for (int x = 1; x < numX - 1; ++x)
                {
                    if (isVisible(x, y))
                    {
                        bestResult += 1;
                    }
                }
            }

            bestResult += numX * 2;
            bestResult += numY * 2;
            bestResult -= 4; // duplicate edges row/column overlap

            return bestResult;
        }

        private int ParseSecond()
        {
            int bestResult = 0;

            int numX = _input[0].Length;
            int numY = _input.Length;

            for (int y = 1; y < numY - 1; ++y)
            {
                for (int x = 1; x < numX - 1; ++x)
                {
                    int result = countScenicScore(x, y);

                    if(result > bestResult)
                    {
                        bestResult = result;
                    }
                }
            }

            return bestResult;
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;
        }

        public void ProcessFirst()
        {
            int bestResult = ParseFirst();

            Console.WriteLine($"{Identifier}.1 bestResult is {bestResult} ");
            Assert.AreEqual(1787, bestResult);
        }

        public void ProcessSecond()
        {
            int bestResult = ParseSecond();

            Console.WriteLine($"{Identifier}.2 bestResult is {bestResult} ");
            Assert.AreEqual(440640, bestResult);
        }
    }
}