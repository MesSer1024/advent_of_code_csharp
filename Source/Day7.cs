using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
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

            PopulateData(input);

            result = ParseFirst();

            result2 += ParseSecond();

            Assert.AreEqual(95437, result);
            Assert.AreEqual(24933642, result2);
        }

        private class Folder
        {
            public int NumBytesInFolder;
            public string Id;
            public Folder? Parent;

            public Folder(string id, Folder? parent)
            {
                Id = id;
                Parent = parent;
                NumBytesInFolder = 0;
            }
        }

        private Dictionary<string, Folder> Folders = new();

        private void PopulateDirectories(string[] lines)
        {
            // find all directories with a total size <= 100.000 (parent directory and child directory can both be unique entries)
            // sum the size of all filtered directories

            Folders.Clear();
            if (lines[0] != "$ cd /") throw new Exception();
            if (lines[1] != "$ ls") throw new Exception();

            // setup root
            Folder dir = new Folder("/", null);
            Folders.Add("/", dir);
            int begin = ProcessFolderUntilNextCommand(lines, 2, dir) + 1;

            for (int i = begin; i < lines.Length; i++)
            {
                // expectation that we process a new command
                var line = lines[i];
                if (!line.StartsWith("$ ")) throw new Exception();

                if (line.StartsWith("$ cd /"))
                {
                    while (dir.Parent != null)
                    {
                        dir = dir.Parent;
                    }
                }
                else if (line.StartsWith("$ cd .."))
                {
                    if (dir.Parent == null) throw new Exception();

                    dir = dir.Parent;
                }
                else if (line.StartsWith("$ cd"))
                {
                    var name = line[5..];
                    var sb = new StringBuilder();
                    FullPathName(sb, dir);
                    sb.Append("/" + name);
                    var fullPath = sb.ToString();
                    dir = Folders[fullPath];
                }
                else if (line.StartsWith("$ ls"))
                {
                    i = ProcessFolderUntilNextCommand(lines, i + 1, dir);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        private void FullPathName(StringBuilder sb, Folder folder)
        {
            if (folder.Parent != null)
            {
                FullPathName(sb, folder.Parent);
            }

            sb.Append("/" + folder.Id);
        }

        private int ProcessFolderUntilNextCommand(string[] lines, int begin, Folder folder)
        {
            void appendBytesRecursively(Folder? recurse, int bytesInFolder)
            {
                while (recurse != null)
                {
                    recurse.NumBytesInFolder += bytesInFolder;
                    recurse = recurse.Parent;
                }

            }

            int i = begin;
            for (; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.StartsWith('$'))
                {
                    // new command, should abort
                    break;
                }
                else if (line.StartsWith("dir "))
                {
                    var name = line[4..];

                    var sb = new StringBuilder();
                    var dir = new Folder(name, folder);

                    FullPathName(sb, dir);
                    var fullPath = sb.ToString();

                    Folders.Add(fullPath, dir);
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

            appendBytesRecursively(folder.Parent, folder.NumBytesInFolder);
            return i-1;
        }

        private int ParseFirst()
        {
            int result = 0;
            foreach (var pair in Folders)
            {
                if (pair.Value.NumBytesInFolder < 100000)
                {
                    result += pair.Value.NumBytesInFolder;
                }
            }

            return result;
        }

        private int ParseSecond()
        {
            // find a directory that we can delete that will make the 'total space available' above 30.000.000
            const int TotalDiskCapacity = 70000000;
            const int DiskRequirementForInstall = 30000000;
            int DiskFreeSpace = TotalDiskCapacity - Folders["/"].NumBytesInFolder;
            int neededSpace = DiskRequirementForInstall - DiskFreeSpace;

            int bestCandidate = int.MaxValue;

            foreach(var pair in Folders)
            {
                int folderSize = pair.Value.NumBytesInFolder;
                if(folderSize >= neededSpace)
                {
                    if(folderSize < bestCandidate)
                    {
                        bestCandidate = folderSize;
                    }
                }
            }

            return bestCandidate;
        }

        public void PopulateData(string[] lines)
        {
            _input = lines;
            PopulateDirectories(_input);
        }

        public void ProcessFirst()
        {
            int result = ParseFirst();

            Console.WriteLine($"{Identifier}.1 result is {result} ");
            Assert.AreEqual(1141028, result);
        }

        public void ProcessSecond()
        {
            int result = ParseSecond();


            Console.WriteLine($"{Identifier}.2 result is {result} ");
            Assert.AreEqual(8278005, result);
        }
    }
}