using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_String
{
    internal class PalindromTask
    {
        public static void OnMain()
        {
            Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
        }

        public static bool IsPalindrome(string s)
        {
            var normal = new string(s.ToLower().Where(c => Char.IsLetterOrDigit(c)).ToArray());
            var reversed = new string(normal.Reverse().ToArray());

            return reversed == normal;
        }
    }
}