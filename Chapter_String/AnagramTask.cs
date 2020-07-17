using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_String
{
    internal class AnagramTask
    {
        public static void OnMain()
        {
            Console.WriteLine(IsAnagram("anagram", "nagrram"));
        }

        public static bool IsAnagram(string s, string t)
        {
            var s1 = new string(s.OrderBy(c => c).ToArray());
            var s2 = new string(t.OrderBy(c => c).ToArray());
            return s1 == s2;
        }
    }
}