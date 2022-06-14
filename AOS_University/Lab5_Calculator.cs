using System;
using System.Collections.Generic;

namespace AOS_University
{
    public class Lab5_Calculator
    {
        private const double t_obs = 0.4;
        private const double lambda_def = 148.3;
        public const int n = 68;
        private double Pw = 0.19;

        private double u = 1 / t_obs;

        public void Calculate()
        {
            Console.WriteLine("Po = " + Get_P_0());
            Console.WriteLine("Pw = " + Get_P_w());
            var dictionary2 = Calculate_2_Lambda();
            Console.WriteLine();
        }

        public Dictionary<double, double> Calculate_2_Lambda()
        {
            var calc_lambda = lambda_def;
            double reduceStep = 0.1;
            double Pw = Get_P_w(lambda: calc_lambda);
            double Pw_increase = Get_P_w(lambda: calc_lambda + reduceStep);
            double Pw_reduce = Get_P_w(lambda: calc_lambda - reduceStep);
            var values_dictionary = new Dictionary<double, double>();
            int steps = 500;
            calc_lambda = lambda_def;
            if (true)
            {
                log("Increase better!", ConsoleColor.Green);
                for (int i = 0; i < steps; i++, calc_lambda += reduceStep)
                {
                    var value = Get_P_w(lambda: calc_lambda);
                    if (calc_lambda == lambda_def || Math.Round(value, 3) == this.Pw)
                    {
                        log($"lambda = {Math.Round(calc_lambda, 3)}\nPw={Math.Round(value, 3)}", ConsoleColor.Red);
                        Console.Beep();
                    }
                    else
                    {
                        log($"lambda = {Math.Round(calc_lambda, 3)}\nPw={Math.Round(value, 3)}", ConsoleColor.Cyan);
                    }

                    values_dictionary.Add(calc_lambda, value);
                }
            }
            else if (Pw_reduce < Pw && Pw_reduce > 0)
            {
                log("Reduce better!", ConsoleColor.Red);
                for (int i = 0; i < steps; i++, calc_lambda -= reduceStep)
                {
                    var value = Get_P_w(lambda: calc_lambda);
                    if (calc_lambda == lambda_def || Math.Round(value, 3) == this.Pw)
                    {
                        log($"lambda = {calc_lambda}\nPw={value}", ConsoleColor.Red);
                        Console.Beep();
                    }
                    else
                    {
                        log($"lambda = {calc_lambda}\nPw={value}", ConsoleColor.Cyan);
                    }
                    values_dictionary.Add(calc_lambda, value);
                }
            }
            else
                log("Nothing...", ConsoleColor.Yellow);

            return values_dictionary;
        }

        public double Get_P_0(int n = n, double t_obs = t_obs, double lambda = lambda_def)
        {
            u = 1 / t_obs;
            double row_sum = Get_Sum_Row(to: n);

            double second_part = u / Get_n_fact_minus(n: n, lambda: lambda); // u / (n-1)! * (nu-l)
            double third_part = Get_lambda_by_u(n, lambda);

            double answer = 1 / (row_sum + second_part * third_part); // Po

            return answer;
        }

        public double Get_P_w(int n = n, double t_obs = t_obs, double lambda = lambda_def)
        {
            if (lambda == 490)
            {
                Console.WriteLine("test");
            }
            u = 1 / t_obs;
            double top_part = u * Get_P_0(n: n, lambda: lambda); // u * Po
            double first_drib = top_part / Get_n_fact_minus(n: n, lambda: lambda);
            double answ = first_drib * Get_lambda_by_u(n, lambda);
            return answ;
        }

        private double Get_n_fact_minus(int n = n, double t_obs = t_obs, double lambda = lambda_def)
        {
            double n_minus_1_fact = Helper.FactTree(n - 1); // (n-1)!
            double n_u_minus_lambda = (n * u) - lambda; // (n * u) - lambda
            double answ = n_minus_1_fact * n_u_minus_lambda;
            return answ;
        }

        private double Get_lambda_by_u(int pow, double l = lambda_def)
        {
            return Math.Pow(l / u, pow);
        }

        private double Get_Sum_Row(int from = 1, int to = n, double l = lambda_def)
        {
            double row_sum = 0;
            for (int i = from; i <= to; i++)
            {
                double k_fact = Helper.FactTree(i);
                double left_side = 1 / k_fact;
                double right_side = Get_lambda_by_u(i, l);
                double answ = left_side * right_side;
                row_sum += answ;
            }
            return row_sum;
        }

        private void log(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("------------------");
            Console.ResetColor();
        }

        public int Get_n()
        {
            return n;
        }
    }
}