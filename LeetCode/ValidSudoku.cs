using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        HashSet<char>[] rows = new HashSet<char>[board.GetLength(0)];
        HashSet<char>[] columns = new HashSet<char>[board.GetLength(0)];
        HashSet<char>[,] quadrants = new HashSet<char>[board.GetLength(0) / 3, board.GetLength(0) / 3];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == '.')
                {
                    continue;
                }
                // Add to row
                if (rows[i] == null)
                {
                    rows[i] = new HashSet<char>();
                }

                if (!rows[i].Add(board[i][j]))
                {
                    return false;
                }


                // Add to column
                if (columns[j] == null)
                {
                    columns[j] = new HashSet<char>();
                }
                if (!columns[j].Add(board[i][j]))
                {
                    return false;
                }


                // Add to quadrants
                if (quadrants[i/3, j/3] == null)
                {
                    quadrants[i / 3, j / 3] = new HashSet<char>();
                }
                if (!quadrants[i / 3,j / 3].Add(board[i][j]))
                {
                    return false;
                }

            }
        }
        return true;
    }
}
