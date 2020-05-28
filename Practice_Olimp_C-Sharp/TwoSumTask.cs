using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class TwoSumTask
    {
        public static void on_Main()
        {
            int[] arr = new int[] { 2, 11, 7, 15 };
            //int[] arr = new int[] { 3, 2, 4 };

            var ans = TwoSum(arr, 9);
        }

        private static int[] TwoSum(int[] arr, int t)
        {
            List<int> nums = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int j = i + 1;
                while (j < arr.Length)
                {
                    if (arr[i] + arr[j] == t)
                    {
                        nums.Add(i);
                        nums.Add(j);
                        return nums.ToArray();
                    }
                    j++;
                }
            }
            return nums.ToArray();
        }
    }
}