using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int upper = matrix.First().Length - 1;
        int lower = 0;
        int row = FindRow(matrix, target);
        Console.WriteLine($"row {row}");


        int index = lower + ((upper - lower) / 2);

        while (matrix[row][index] != target)
        {
            Console.WriteLine($"Try {index}, at row:{row} with upper {upper} and lower {lower}");
            if (matrix[row][index] < target)
            {
                if (lower == index)
                {
                    lower = upper;
                }
                else
                {
                    lower = index + 1;
                }
            }
            else if (matrix[row][index] > target)
            {
                if (upper == index)
                {
                    upper = lower;
                }
                else
                {
                    upper = index - 1;
                }
            }
            index = (lower + upper) / 2;
            if (upper <= lower)
            {
                if (matrix[row][index] != target)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        if (matrix[row][index] == target)
        {
            return true;
        }
        return false;
    }

    public int FindRow(int[][] matrix, int target)
    {
        int lower = 0;
        int upper = matrix.Length - 1;

        int mid = lower + ((upper - lower) / 2);
        while(lower != upper)
        {
            Console.WriteLine($"mid: {mid}");
            if (matrix[mid][0] > target)
            {
                upper = mid - 1;
            } else if (matrix[mid][matrix.First().Length - 1] < target)
            {
                lower = mid + 1;
            }
            else if (matrix[mid][0] <= target && matrix[mid][matrix.First().Length - 1] >= target)
            {
                return mid;
            }
            mid = lower + ((upper - lower) / 2);
        }
        return mid;
    }
}

//public class Solution
//{
//    public bool SearchMatrix(int[][] matrix, int target)
//    {
//        int ROWS = matrix.Length;
//        int COLS = matrix[0].Length;
//        int top = 0, bot = ROWS - 1;
//        int row = 0;

//        while (top <= bot)
//        {
//            row = (top + bot) / 2;
//            if (target > matrix[row][COLS - 1]) top = row + 1;
//            else if (target < matrix[row][0]) bot = row - 1;
//            else break;
//        }

//        if (top > bot) return false;

//        int l = 0, r = COLS - 1;

//        while (l <= r)
//        {
//            int m = (l + r) / 2;
//            if (target > matrix[row][m]) l = m + 1;
//            else if (target < matrix[row][m]) r = m - 1;
//            else return true;
//        }

//        return false;
//    }
//}