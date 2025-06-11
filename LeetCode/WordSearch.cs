using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class Solution
{
    private char[][] board;
    private int[,] directions = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
    private string word;

    public bool Exist(char[][] board, string word)
    {
        this.board = board;
        this.word = word;
        bool[,] visited;
        for(int i  = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (word[0] == board[i][j])
                {
                    if(word.Length == 1)
                    {
                        return true;
                    }
                    visited = new bool[board.Length, board[0].Length];
                    visited[i, j] = true;
                    if (DFS(visited, (i, j), 1))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool DFS(bool[,] visited, (int, int) coords, int index)
    {
        //Console.WriteLine($"at coords {coords}, index {index}");
        for(int i = 0; i < directions.GetLength(0); i++) {
            //Console.WriteLine($"Directions Length {directions.GetLength(0)}");
            int y = directions[i, 1] + coords.Item1;
            int x = directions[i, 0] + coords.Item2;
            //Console.WriteLine($"pre if x {x}, y {y}");
            if(x >= 0 && y >= 0 && y < board.Length && x < board[0].Length && !visited[y, x])
            {
                //Console.WriteLine($"Checking y {y}, x {x}");
                if (word[index] == board[y][x])
                {
                    //Console.WriteLine($"index {index} length: {word.Length - 1}");
                    if(index == word.Length - 1)
                    {
                        return true;
                    }
                    bool[,] newVisited = (bool[,])visited.Clone();
                    newVisited[y, x] = true;
                    if (DFS(newVisited, (y, x), index + 1)) 
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
