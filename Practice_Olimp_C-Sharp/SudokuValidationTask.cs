using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class SudokuValidationTask
    {
        public static void onMain()
        {
            char[][] board = new char[][]
            {
                new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };
            Console.WriteLine(board[2][1]);
            Console.WriteLine(IsValidSudoku(board));
        }

        public static bool IsValidSudoku(char[][] board)
        {
            HashSet<string> vals = new HashSet<string>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        char val = board[i][j];
                        if (
                            !vals.Add(val + "In row" + i) ||
                            !vals.Add(val + "In col" + j) ||
                            !vals.Add(val + "In box" + i / 3 + " " + j / 3)
                            )
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}