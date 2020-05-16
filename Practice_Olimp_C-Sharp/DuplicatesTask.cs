using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class DuplicatesTask
    {
        public static int[] array = new int[] { 1, 6, 4, 2, 4, 1, 199, 30, 41, 2, 3 };
        public static int[] array2 = new int[] { 1, 6, 4, 2, 199, 30, 41, 3 };
        public static int[] array3 = new int[] { 0 };
        public static int[] array4 = new int[] { 1, 5, -2, -4, 0 };
        public static int[] array5 = new int[] { 2, 14, 18, 22, 22 };

        public static void OnMain()
        {
            // Console.WriteLine(FindDuplicatesFirst(array));
            //Console.WriteLine(FindDuplicatesFirst(array2));
            //Console.WriteLine(FindDuplicatesFirst(array3));
            //Console.WriteLine(FindDuplicatesFirst(array4));
            //Console.WriteLine(FindDuplicatesFirst(array5));
            Console.WriteLine(FindDuplicatesSecond(array3));
            //Console.WriteLine(FindDuplicatesSecond(array2));
            // Console.WriteLine(FindDuplicatesSecond(array3));
            //Console.WriteLine(FindDuplicatesSecond(array4));
            //Console.WriteLine(FindDuplicatesSecond(array5));
        }

        private static bool FindDuplicatesFirst(int[] arr)
        {
            Program.Print(arr);
            Program.arr_sort(arr, 0);
            Program.Print(arr);
            if (arr.Length == 1)
            {
                return false;
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool FindDuplicatesSecond(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                {
                    return true;
                }
                else
                {
                    dict.Add(arr[i], arr[i]);
                }
            }
            return false;
        }
    }
}