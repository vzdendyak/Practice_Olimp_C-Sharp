using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_String
{
    internal class StringToIntegerTask
    {
        public static void onMain()
        {
            Console.WriteLine(MyAtoi(""));
        }

        public static int MyAtoi(string str)
        {
            bool isNegative = false;
            bool isBad = false;
            StringBuilder newStr = new StringBuilder();
            if (str.Length == 0)
            {
                return 0;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '-')
                {
                    isNegative = true;
                    i++;
                    for (int j = i; j < str.Length; j++)
                    {
                        if (!"1234567890".Contains(str[j]))
                        {
                            break;
                        }
                        newStr.Append(str[j]);
                    }
                    break;
                }
                if (str[i] == '+')
                {
                    i++;
                    for (int j = i; j < str.Length; j++)
                    {
                        if (!"1234567890".Contains(str[j]))
                        {
                            break;
                        }
                        newStr.Append(str[j]);
                    }
                    break;
                }
                if ("1234567890".Contains(str[i]))
                {
                    for (int j = i; j < str.Length; j++)
                    {
                        if (!"1234567890".Contains(str[j]))
                        {
                            break;
                        }
                        newStr.Append(str[j]);
                    }
                    break;
                }
                if (str[i] != ' ')
                {
                    isBad = true;
                    break;
                }
            }

            bool aInt = long.TryParse(newStr.ToString(), out var re1);
            if (isBad)
            {
                return 0;
            }
            else
            {
                if (aInt && re1 < int.MaxValue)
                {
                    return isNegative ? int.Parse(newStr.ToString()) * -1 : int.Parse(newStr.ToString());
                }
                else
                {
                    return isNegative ? int.MaxValue * -1 - 1 : int.MaxValue;
                }
            }
        }
    }
}