using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class RotateMatrix
    {
        public static void OnMain()
        {
            int[][] matrix =
            {
               new int[] {1,2,3},
               new int[] {4,5,6},
               new int[] {7,8,9}
            };
            Rotate(matrix);
        }

        public static void Rotate(int[][] matrix)
        {
            var n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = temp;
                }
            }
            Console.WriteLine();
        }
    }
}