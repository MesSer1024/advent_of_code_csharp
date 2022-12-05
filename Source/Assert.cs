using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advent_of_code_csharp.Source
{
    public static class Assert
    {
        public static void IsTrue(bool condition)
        {
            if(!condition) throw new Exception();
        }

        public static void AreEqual(int a, int b)
        {
            if(a != b) throw new Exception();
        }

        public static void AreEqual(string a, string b)
        {
            if(string.Compare(a, b, false) != 0) throw new Exception();
        }
    }
}