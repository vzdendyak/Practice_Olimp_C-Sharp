using System;
using System.Collections.Generic;

namespace Practice_Olimp_C_Sharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //DuplicatesTask.OnMain();
            CryptMethods.psevdo_Main();
            Console.WriteLine();
        }

        #region Перебір всіх підможин без повторень (звич + рекурсія)

        // Перебір всіх підможин без повторень
        private static void perebirMnog(int k)
        {
            string allEl = "";
            for (int i = 1; i <= k; i++)
            {
                Console.WriteLine($"{{{i}}}");
                allEl += $"{i},";
                for (int j = i + 1; j <= k; j++)
                {
                    Console.WriteLine($"{{{i},{j}}}");
                }
            }
            Console.WriteLine($"{{{allEl}}}");
        }

        //Перебір всіх підможин без повторень - рекурсія
        private static void perebirMnogRecurs(int n, int k)
        {
            if (n > k)
            {
                Console.Write("{");
                for (int i = 1; i <= k; i++)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine("}");
            }
            else
            {
                Console.WriteLine($"{{{n}}}");
                for (int i = n + 1; i <= k; i++)
                {
                    Console.WriteLine($"{{{n},{i}}}");
                }
                perebirMnogRecurs(n + 1, k);
            }
        }

        #endregion Перебір всіх підможин без повторень (звич + рекурсія)

        #region Перебір усіх перестановок з n елементів

        // Перебір усіх перестановок з n елементів
        private static void perestanovka(int[] arr, int n)
        {
            bool state = false;
            while (!state)
            {
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    if (arr[i - 1] < arr[i])
                    {
                        Print(arr);
                        swap(arr, i - 1, find_min_arr(arr, i));
                        arr_sort(arr, i);
                        state = false;
                        break;
                    }
                    else
                    {
                        state = true;
                    }
                }
            }
            Print(arr); return;
        }

        public static void arr_sort(int[] arr, int n)
        {
            for (int i = n; i < arr.Length - 1; i++)
            {
                for (int j = n; j < arr.Length - i - 1 + n; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // меняем элементы местами
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        private static int find_min_arr(int[] arr, int n)
        {
            int max = arr[n];
            int maxIndex = n;
            for (int i = n; i < arr.Length; i++)
            {
                if (arr[i] < max && arr[i] > arr[n - 1])
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        private static void swap(int[] a, int i, int j)
        {
            int s = a[i];
            a[i] = a[j];
            a[j] = s;
        }

        #endregion Перебір усіх перестановок з n елементів

        #region Знайти максимально велики підмасив в масиві

        private static void MaxSumSubArrayMain(int[] arr)
        {
            int max, start, end;
            max = start = end = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                (int maxTemp, int startTemp, int endTemp) = MaxSumSubArrayEffective(i, arr);
                if (max < maxTemp)
                {
                    max = maxTemp;
                    start = startTemp;
                    end = endTemp;
                }
            }
            Console.WriteLine($"\nCALCULATED\nStart: {start}\nEnd: {end}\nSum: {max}");
            Console.Write("Elements: { ");
            for (int i = start; i < end + 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine(" } ");
        }

        private static (int, int, int) MaxSumSubArrayEffective(int j, int[] arr)
        {
            int max, sum, pointer = 0;
            max = sum = 0;
            for (int i = j; i < arr.Length; i++)
            {
                sum += arr[i];
                if (max < sum)
                {
                    pointer = i;
                    max = sum;
                }
                //Console.WriteLine($"Sum: {sum} | Position: {i}");
                //Console.WriteLine($"{i}. {arr[i]} | {sum} ");
            }
            Console.WriteLine(max + "  " + pointer);
            return (max, j, pointer);
        }

        #endregion Знайти максимально велики підмасив в масиві

        private static void CycleSorting(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] - 1 != i)
                {
                    int temp = arr[arr[i] - 1];
                    arr[arr[i] - 1] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        public static int RemoveDuplicates1(int[] nums)
        {
            int element = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                int n = nums[i];
                for (int j = i; j < nums.Length; j++)
                {
                    if (n != nums[j])
                    {
                        element++;
                        i = j - 1;
                        break;
                    }
                }
            }
            return element;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            int element = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[element])
                {
                    element++;
                    nums[element] = nums[j];
                }
            }

            return element + 1;
        }

        public static int MaxProfit(int[] prices)
        {
            int i = 0;
            int up = prices[0];
            int down = prices[0];
            int max = 0;
            while (i < prices.Length - 1)
            {
                while (i < prices.Length - 1 && prices[i] >= prices[i + 1])
                    i++;
                down = prices[i];
                while (i < prices.Length - 1 && prices[i] <= prices[i + 1])
                    i++;
                up = prices[i];
                max += up - down;
            }

            return max;
        }
    }
}