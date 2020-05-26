using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class Single_number
    {
        public static void on_Main()
        {
            int[] arr = new int[] { 2, 1, 2, 1, 3, 5, 5, 4, 6, 3, 6 };

            Console.WriteLine(SingleNumber(arr));
        }

        private static int SingleNumber(int[] arr)
        {
            int temp = arr[0];
            bool found = false;
            Program.arr_sort(arr, 0);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != arr[i + 1])
                {
                    temp = arr[i];
                    found = true;
                    break;
                }
                i++;
            }
            if (found == false)
            {
                temp = arr[arr.Length - 1];
            }
            return temp;
        }
    }
}