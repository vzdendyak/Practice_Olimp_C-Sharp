using System;
using System.Collections.Generic;
using System.Text;

namespace MyStudy
{
    internal class Chapter2
    {
        public static void OnMain()
        {
            var numbers = GetNumbers();
            Print(numbers);
        }

        private static void Print(IEnumerable<int> arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<int> GetNumbers()
        {
            var number = 0;
            while (true)
            {
                if (number > 10)
                    yield break;

                yield return number++;
            }
        }
    }
}