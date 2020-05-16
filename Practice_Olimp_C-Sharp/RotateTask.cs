using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class RotateTask
    {
        static public int[] arr1 = new int[] { 1, 2, 3, 4 };

        public static void PostMain()
        {
            //RotateArrFirstVariant(arr1, 5);
            RotateArrSecondVariant(arr1, 6);
        }

        private static void RotateArrFirstVariant(int[] arr, int k)
        {
            int temp = 0;
            for (int j = 0; j < k; j++)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == 0)
                    {
                        int p = arr[arr.Length - 1];
                        temp = arr[0];
                        arr[0] = p;
                        continue;
                    }
                    int temp2 = arr[i];
                    arr[i] = temp;
                    temp = temp2;
                }
            }
        }

        private static void RotateArrSecondVariant(int[] arr, int k)
        {
            int[] arrNew = new int[arr.Length];
            int i = 0, j = 0;
            k = k % arr.Length;
            while (i < k)
            {
                if (i >= arr.Length)
                {
                    i = 0;
                }
                arrNew[k - i - 1] = arr[arr.Length - 1 - i];
                i++;
            }
            while (i < arr.Length)
            {
                arrNew[i] = arr[j];
                j++; i++;
            }
            arrNew.CopyTo(arr, 0);
        }

        private static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}