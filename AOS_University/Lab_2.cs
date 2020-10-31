using System;
using System.Collections.Generic;
using System.Text;

namespace AOS_University
{
    public class Lab_2
    {
        public double t_obs = 0.1;
        public double lambda = 100;
        public double n = 15;
        public double P_nobs = 0.943;
        public double P_t = 0.9;
        public double P_lambda = 0.64;
        //public double t_obs = 0.2;

        //public double n = 11;
        //public double lambda = 45;
        //public double p_n = 0.966;
        //public double p_t = 0.89;
        //public double p_lambda = 0.925;

        public void calculateMain()
        {
            int ans = 0;
            ans = calculate(n);
            while (ans != 0)
            {
                if (ans == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("--------------------");
                    Console.ResetColor();
                    n += 1;
                    ans = calculate(n);
                    continue;
                }
                else if (ans == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("--------------------");
                    Console.ResetColor();
                    n -= 1;
                    ans = calculate(n);
                    continue;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"answer = {ans}\nn={n}");
            Console.ResetColor();
        }

        public int calculate(double n)
        {
            double P_0, P_n, P_obs, alfa, sum, N_k, K_zan, N_0, K_prostoiu;
            P_0 = P_n = P_obs = sum = alfa = N_k = K_zan = 0;
            alfa = lambda * t_obs;
            Console.WriteLine($"alfa = lambda * t_obs = {lambda} * {t_obs} = {alfa}");

            for (int i = 0; i <= n; i++)
            {
                var pow = Math.Pow(alfa, i);
                var fact = FactTree(i);
                var temp = pow / fact;
                sum += temp;
                if (i == n)
                    Console.WriteLine($"----------\ni = {i}\npow = {pow}\nfact = {fact}\ntemp = {temp}\nsum = {sum}");
            }
            P_0 = 1 / sum;
            Console.ResetColor();
            Console.WriteLine($"P_0 = {P_0}");
            P_n = Math.Pow(alfa, n) / (FactTree((int)n)) * P_0;
            Console.WriteLine($"P_n = {P_n}");
            P_obs = 1 - P_n;
            Console.WriteLine($"P_обслуговування = {P_obs}");
            N_k = alfa * P_obs;
            Console.WriteLine($"N_k = {N_k}");
            K_zan = N_k / n;
            Console.WriteLine($"K_занятостi = {K_zan}");
            sum = 0;
            for (int k = 0; k <= n; k++)
            {
                var pow = Math.Pow(alfa, k);
                var fact = FactTree(k);
                var temp = (pow * (n - k)) / fact;
                sum += temp;
                if (k == n)
                    Console.WriteLine($"----------\ni = {k}\npow = {pow}\nfact = {fact}\ntemp = {temp}\nsum = {sum}");
            }
            Console.ResetColor();
            N_0 = sum * P_0;
            Console.WriteLine($"N_0 = {N_0}");
            K_prostoiu = N_0 / n;
            Console.WriteLine($"K_prostoiu = {K_prostoiu}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"n = {n}");
            Console.ResetColor();

            if (Math.Round(P_nobs, 3) == Math.Round(P_obs, 3))
                return 0;
            else if (Math.Round(P_nobs, 3) < Math.Round(P_obs, 3))
                return -1;
            else
                return 1;
        }

        private static double ProdTree(int l, int r)
        {
            if (l > r)
                return 1;
            if (l == r)
                return l;
            if (r - l == 1)
                return (double)l * r;
            int m = (l + r) / 2;
            return ProdTree(l, m) * ProdTree(m + 1, r);
        }

        private static double FactTree(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            return ProdTree(2, n);
        }
    }
}