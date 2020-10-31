using System;

namespace AOS_University
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Lab_1 l1 = new Lab_1();
            Lab_2 l2 = new Lab_2();
            Lab_3 l3 = new Lab_3();
            Lab_4 l4 = new Lab_4();
            Lab5_Calculator l5 = new Lab5_Calculator();

            //l2.calculateMain();
            //l3.calculateMain();
            //l4.calculateMain();
            //l1.calculateMain();
            l5.Calculate();
        }
    }
}