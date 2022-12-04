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
            // var extensionSecond = "_p2.txt";

            var first = new FileInfo(Environment.CurrentDirectory + root + day.Identifier + extensionFirst);
            // var second = new FileInfo(Environment.CurrentDirectory + root + day.Identifier + extensionSecond);

            day.ProcessExample();

            if(!first.Exists) throw new Exception();

            var lines = File.ReadAllLines(first.FullName);
            day.PopulateData(lines);
            day.ProcessFirst();

            // if(!second.Exists && !day.SameData) throw new Exception();
            day.ProcessSecond();

        }
    }

    internal class Program
    {
        private static void RunAll()
        {
            var type = typeof(IDay);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            var arr = types.ToArray();

            foreach(var t in arr)
            {
                var ctor = t.GetConstructor(Array.Empty<Type>());
                var foo = (IDay)ctor.Invoke(null);
                Installer.Install(foo);
            }
        }

        static void Main(string[] args)
        {
            RunAll();
            // var day = new Day5();
            // Installer.Install(day);
        }
    }
}