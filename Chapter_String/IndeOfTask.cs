using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chapter_String
{
    internal class IndeOfTask
    {
        public static void OnMain()
        {
            Console.WriteLine(StrStr("misisippi", "isip"));
        }

        public static int StrStr(string haystack, string needle)
        {
            if (String.IsNullOrWhiteSpace(needle))
            {
                return 0;
            }
            if (String.IsNullOrWhiteSpace(haystack))
                return -1;

            int index = -1;

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    int tempIndex;
                    if (haystack.Length - i < needle.Length)
                    {
                        continue;
                    }
                    string tempStr = haystack.Substring(i, needle.Length);
                    if (tempStr == needle)
                    {
                        return i;
                    }
                    continue;
                }
            }

            return index;
        }
    }
}