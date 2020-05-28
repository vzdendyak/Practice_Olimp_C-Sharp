using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class ArraysIntersection
    {
        public static void on_Main()
        {
            //int[] arr1 = new int[] { 1, 2, 2, 1 };
            int[] arr1 = new int[] { 4, 9, 5 };
            //int[] arr2 = new int[] { 2, 2 };
            int[] arr2 = new int[] { 9, 4, 9, 8, 4 };
            //int[] arraysIntersect = Intersection(arr1, arr2);
            int[] plusOneArr = PlusOne(arr1);
            Program.Print(plusOneArr);
        }

        private static int[] Intersection(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> intersect = new Dictionary<int, int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        if (!intersect.ContainsKey(j))
                        {
                            intersect.Add(j, arr2[j]);
                            break;
                        }
                    }
                }
            }

            return intersect.Values.ToArray();
        }

        private static int[] PlusOne(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    int temp = arr[i] + 1;

                    arr[i] = temp;
                }
            }
            return arr;
        }
    }
}