using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_String
{
    internal class ReverseInteger
    {
        public static void OnMain()
        {
            Console.WriteLine(Reverse(1534236469));
        }

        public static int Reverse(int x)
        {
            string plainText = "";

            var reversed = x.ToString().Reverse().TakeWhile(c => c != '-');
            foreach (var item in reversed)
            {
                plainText += item;
            }
            if (x < 0)
            {
                plainText = '-' + plainText;
            }
            try
            {
                x = int.Parse(plainText);
            }
            catch (Exception)
            {
                return 0;
            }
            return x;
        }
    }
}