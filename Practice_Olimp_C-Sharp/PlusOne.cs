using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class PlusOne
    {
        public static void onMain()
        {
            int[] arr = { 9 };
            Program.Print(PlusOneMethod(arr));
        }

        public static int[] PlusOneMethod(int[] arr)
        {
            var len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                if (i != len - 1)
                    continue;
                if (arr[i] == 9)
                {
                    int j = i - 1;
                    arr[i] = 0;
                    while (j > 0 && arr[j] == 9)
                    {
                        arr[j] = 0;
                        j--;
                    }
                    if (j < 0 || arr[j] == 9)
                    {
                        int[] newArr = new int[len + 1];
                        for (int k = 0; k < len + 1; k++)
                        {
                            newArr[k] = 0;
                        }
                        newArr[0] = 1;
                        return newArr;
                    }
                    arr[j]++;
                }
                else
                {
                    arr[i]++;
                }
            }

            return arr;
        }
    }
}