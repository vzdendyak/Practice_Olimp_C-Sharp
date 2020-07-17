using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter_String
{
    internal class ReverseStringTask
    {
        public static void OnMain()
        {
            string s = "John";
            ReverseString(s.ToCharArray());
        }

        public static void ReverseString(char[] s)
        {
            Console.WriteLine(s);

            int end = s.Length - 1;
            int start = 0;

            for (int i = 0; i < s.Length / 2; i++)
            {
                var temp = s[i];
                s[i] = s[end];
                s[end] = temp;
                end--;
            }
            Console.WriteLine(s);
        }
    }
}