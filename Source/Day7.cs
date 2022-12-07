using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public class Day7 : IDay
    {
        public string Identifier => "day7";
        private string[] _input = Array.Empty<string>();

        public void ProcessExample()
        {
            var input = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k".Split(Environment.NewLine);

            int result = 0;
            int result2 = 0;

            foreach (var line in input)
            {
                result += ParseFirst(line);
            }

            foreach (var line in input)
            {
                result2 += ParseSecond(line);
            }

            Assert.AreEqual(95437, result);
            Assert.AreEqual(0, result2);
        }

        private class Folder
        {
            public int NumBytesInFolder;
            // public string Id;
            public Folder? Parent;

            public Folder(string id, Folder? parent)
            {
                // Id = id;
                Parent = parent;
                NumBytesInFolder = 0;
            }
        }

        private Dictionary<string, Folder> Folders = new();

        private int ParseFirst(string[] lines)
        {
            int output = 0;
            int nextLine = 0;

            // find all directories with a total size <= 100.000 (parent directory and child directory can both be unique entries)
            // sum the size of all filtered directories

            {
                // setup root
                if (lines[0] != "cd /") throw new Exception();
                if (lines[1] != "$ ls") throw new Exception();

                var dir = new Folder("/", null);
                Folders.Add("/", dir);
                nextLine = ProcessFolderUntilNextCommand(lines, 2, dir);
            }


            for (int i = 2; i < lines.Length; i++)
            {
                var line = lines[i];
                if (!line.StartsWith("$ ")) throw new Exception();

                if (line.StartsWith("$ cd "))
                {
                    var name = line[5..];
                    var dir = Folders[name];
                }
            }


            return output;
        }

        private int ProcessFolderUntilNextCommand(string[] lines, int begin, Folder folder)
        {
            for (int i = begin; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.StartsWith('$'))
                {
                    // new command, abort
                    return i - 1;
                }
                else if (line.StartsWith("dir "))
                {
                    var name = line[4..];
                    Folders.Add(name, new Folder(name, folder));
                }
                else
                {
                    // file, pattern [int, string]
                    var parts = line.Split(' ');
                    if (parts.Length != 2) throw new Exception();

                    int fileSize = int.Parse(parts[0]);
                    string fileName = parts[1];

                    folder.NumBytesInFolder += fileSize;
                }
            }
            return lines.Length;
        }

        private int ParseSecond(string line)
        {
            return 0;
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;
        }

        public void ProcessFirst()
        {
            int result = 0;


            Console.WriteLine($"{Identifier}.1 result is {result} ");
            Assert.AreEqual(0, result);
        }

        public void ProcessSecond()
        {
            int result = 0;


            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(0, result);
        }
    }
}