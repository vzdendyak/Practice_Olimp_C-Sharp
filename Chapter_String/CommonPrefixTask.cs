using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_String
{
    internal class CommonPrefixTask
    {
        public static void OnMain()
        {
            Console.WriteLine(LongestCommonPrefix(new string[] { "aa", "ab", "" }));
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return "";
            }
            var longest = strs.OrderByDescending(s => s.Length).FirstOrDefault();
            StringBuilder pref = new StringBuilder();
            bool state = true;
            for (int i = 0; i < longest.Length; i++)
            {
                pref.Append(longest[i]);

                for (int j = 0; j < strs.Length; j++)
                {
                    if (strs[j].Length == 0)
                    {
                        return "";
                    }

                    if (!(strs[j].Length < pref.Length) && strs[j].Substring(0, pref.Length) == pref.ToString())
                    {
                        continue;
                    }
                    state = false;
                    break;
                }
                if (!state)
                {
                    return pref.ToString().Substring(0, pref.Length - 1);
                }
            }

            return pref.ToString();
        }
    }
}