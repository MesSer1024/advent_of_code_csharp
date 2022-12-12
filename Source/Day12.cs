using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{

    public class Day12 : IDay
    {
        private class Node
        {
            public int X;
            public int y;
            public int Index;

            public char Elevation;

            public int NumSteps = 0;
            public Node? Parent = null;
        }

        private class Graph
        {
            public List<Node> Nodes = new();

            public readonly Node start;
            public readonly Node goal;

            private readonly int NumRows;
            private readonly int NumCols;


            public Graph(string[] input)
            {
                NumRows = input.Length;
                NumCols = input[0].Length;

                for (int y = 0; y < input.Length; y++)
                {
                    string line = input[y];

                    if (line.Length != NumCols)
                    {
                        throw new Exception();
                    }


                    for (int x = 0; x < line.Length; x++)
                    {
                        char c = line[x];

                        var n = new Node();
                        n.X = x;
                        n.y = y;
                        n.Index = Nodes.Count;
                        n.Elevation = c;

                        Nodes.Add(n);

                        if (c == 'S')
                        {
                            start = n;
                            n.Elevation = 'a';
                        }
                        else if (c == 'E')
                        {
                            goal = n;
                            n.Elevation = 'z';
                        }
                    }
                }

                if (start == default || goal == default)
                    throw new Exception();
            }

            public void ForeachUnvisitedNeighbour(Node node, Action<Node> action)
            {
                // check left
                if (node.X > 0)
                {
                    var other = Nodes[node.Index - 1];
                    action(other);
                }

                // check right
                if (node.X < NumCols - 1)
                {
                    var other = Nodes[node.Index + 1];
                    action(other);
                }

                // check up
                if (node.y > 0)
                {
                    var other = Nodes[node.Index - NumCols];
                    action(other);
                }

                // check down
                if (node.y < NumRows - 1)
                {
                    var other = Nodes[node.Index + NumCols];
                    action(other);
                }
            }
        }

        public string Identifier => "day12";
        private string[] _input = Array.Empty<string>();
        private Graph? _graph;

        public void ProcessExample()
        {
            var input = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi".Split(Environment.NewLine);

            PopulateData(input);

            int result = ParseFirst();
            PrintGraph();
            int result2 = ParseSecond();

            Assert.AreEqual(31, result);
            Assert.AreEqual(0, result2);
        }

        private void PrintGraph()
        {
            if (_graph == null || _graph.goal == null)
                throw new Exception();

            var node = _graph.goal;

            var output = new StringBuilder[_input[0].Length];


            for (int i = 0; i < _input.Length; i++)
            {
                var sb = new StringBuilder(_input[0].Length);
                foreach(var c in _input[0])
                    sb.Append('.');
                output[i] = sb;
            }

            while (node.Parent != null)
            {
                var sb = output[node.Parent.y];
                var parent = node.Parent;

                if(parent.X != node.X)
                {
                    // x-axis
                    if(parent.X > node.X)
                    {
                        // parent is to the left
                        sb[parent.X] = '<';
                    }
                    else
                    {
                        sb[parent.X] = '>';
                    }
                }
                else
                {
                    // y-axis
                    if(parent.y > node.y)
                    {
                        // parent is above
                        sb[parent.X] = '^';
                    }
                    else
                    {
                        sb[parent.X] = 'v';
                    }
                }

                node = node.Parent;
            }



            foreach(var sb in output)
            {
                Console.WriteLine(sb);
            }
        }

        private int ParseFirst()
        {
            if (_graph == null) throw new Exception();

            int NumNodes = _graph.Nodes.Count;

            Node[] queue = new Node[NumNodes];
            bool[] isQueued = new bool[NumNodes];
            bool reachedGoal = false;

            int iterationIt = 0;
            int placementIt = 0;

            queue[placementIt++] = _graph.start;
            isQueued[_graph.start.Index] = true;

            while (iterationIt < placementIt && reachedGoal == false /* #todo : might need to finish queue? */)
            {
                var node = queue[iterationIt++];

                _graph.ForeachUnvisitedNeighbour(node, neighbour =>
                {

                    var prevHeight = node.Elevation;
                    var neighbourHeight = neighbour.Elevation;

                    if (neighbourHeight > prevHeight + 1)
                    {
                        // ignore nodes with bad elevation
                        return;
                    }

                    if (neighbour == _graph.goal)
                    {
                        neighbour.Parent = node;
                        neighbour.NumSteps = node.NumSteps + 1;
                        reachedGoal = true;
                        return;
                    }

                    if (isQueued[neighbour.Index])
                    {
                        // revisiting node
                        bool isBetterParent = neighbour.Parent != node && (neighbour.NumSteps > (node.NumSteps + 1));
                        if (isBetterParent)
                        {
                            neighbour.Parent = node;
                            neighbour.NumSteps = node.NumSteps + 1;
                            throw new Exception(); // #todo : also need to process all nodes linking to this parent if we have allready processed this item inside queue... ??
                        }
                    }
                    else
                    {
                        // first visit
                        isQueued[neighbour.Index] = true;
                        neighbour.Parent = node;
                        neighbour.NumSteps = node.NumSteps + 1;
                        queue[placementIt++] = neighbour;
                    }
                });
            }

            return _graph.goal.NumSteps;
        }

        private int ParseSecond()
        {
            int result = 0;


            return result;
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;
            _graph = new Graph(lines);

        }

        public void ProcessFirst()
        {
            int result = ParseFirst();

            Console.WriteLine($"{Identifier}.1 result is {result} ");
            PrintGraph();
            Assert.AreEqual(449, result);
        }

        public void ProcessSecond()
        {
            int result = ParseSecond();

            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(0, result);
        }
    }
}