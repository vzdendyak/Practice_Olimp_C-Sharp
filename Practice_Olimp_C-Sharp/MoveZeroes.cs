using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class MoveZeroes
    {
        public static void on_Main()
        {
            int[] arr = new int[] { 0, 1, 0, 3, 12 };
            Program.Print(arr);
            MoveZeroesFunc(arr);
            Program.Print(arr);
        }

        private static void MoveZeroesFunc(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    int j = i;
                    while (arr[j] == 0 && j != arr.Length - 1) { j++; }

                    if (arr[j] == 0)
                    {
                        break;
                    }
                    arr[i] = arr[j];
                    arr[j] = 0;
                    i = -1;
                }
            }
        }
    }
}