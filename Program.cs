using System;
using advent_of_code_csharp.Source;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal static class Installer
    {
        public static void Install(IDay day)
        {

            var root = "./Resources/2022/";
            var extensionFirst = "_p1.txt";
            var extensionSecond = "_p2.txt";

            var first = new FileInfo(Environment.CurrentDirectory + root + day.Identifier + extensionFirst);
            var second = new FileInfo(Environment.CurrentDirectory + root + day.Identifier + extensionSecond);

            day.ProcessExample();

            if(!first.Exists) throw new Exception();

            var lines = File.ReadAllLines(first.FullName);
            day.ProcessFirst(lines);

            if(!second.Exists && !day.SameData) throw new Exception();
            day.ProcessSecond(lines);

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            var day = new Day4();
            Installer.Install(day);

        }


    }
}