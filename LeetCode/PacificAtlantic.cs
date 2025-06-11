using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    enum Ocean
    {
        None,
        Both,
        Atl,
        Pac
    }

    bool[][] AtlConnected;
    bool[][] PacConnected;
    Ocean[][] connection;

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        List<IList<int>> result = new();
        List<(int, int)> directions = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0) };
        // Lets do it in reverse
        // Fill up the array with ATLConnected and PAC(edge nodes)
        // Add them to the queue  and lets run a BFS
        int m = heights.Length;
        int n = heights[0].Length;
        Stack<(int, int)> stack= new();

        connection = new Ocean[m][];
        PacConnected = new bool[m][];
        PacConnected[0] = new bool[n];
        for(int x = 0; x < n; x++)
        {
            PacConnected[0][x] = true;
            stack.Push((0, x));
            Console.WriteLine($"PacConnected 0 {x}");
        }
        for (int y = 0; y < m; y++)
        {
            if(y!= 0)
            {
                PacConnected[y] = new bool[m];
            }
            PacConnected[y][0] = true;
            stack.Push((y, 0));
            Console.WriteLine($"PacConnected {y} 0");
        }

        AtlConnected = new bool[m][];
        AtlConnected[m-1] = new bool[n];
        for (int x = 0; x < n; x++)
        {
            AtlConnected[m - 1][x] = true;
            stack.Push((m-1, x));
            Console.WriteLine($"AtlConnected {m - 1} {x}");
        }
        for (int y = 0; y < m; y++)
        {
            if (y != n-1)
            {
                AtlConnected[y] = new bool[n];
            }
            AtlConnected[y][n-1] = true;
            stack.Push((y, n-1));
            Console.WriteLine($"AtlConnected {y} {n-1}");
        }

        while(stack.Count > 0)
        {
            (int, int) curr = stack.Pop();
            Console.WriteLine($"Checking at {curr.Item1} and {curr.Item2}");
            foreach ((int, int) direction in directions)
            {
                (int, int) newCurr = (direction.Item1 + curr.Item1, direction.Item2 + curr.Item2);
                if(newCurr.Item1 >= 0 && newCurr.Item1 < m && 
                    newCurr.Item2 >= 0 && newCurr.Item2 < n &&
                    ((AtlConnected[curr.Item1][curr.Item2] && !AtlConnected[newCurr.Item1][newCurr.Item2]) ||
                         (PacConnected[curr.Item1][curr.Item2] && !PacConnected[newCurr.Item1][newCurr.Item2]) ) &&
                    heights[curr.Item1][curr.Item2] <= heights[newCurr.Item1][newCurr.Item2])
                {
                    if (AtlConnected[curr.Item1][curr.Item2] && !AtlConnected[newCurr.Item1][newCurr.Item2])
                    {
                        AtlConnected[newCurr.Item1][newCurr.Item2] = true;
                        stack.Push((newCurr.Item1, newCurr.Item2));
                        Console.WriteLine($"ATL connected at {newCurr.Item1} and {newCurr.Item2}");
                    }
                    if (PacConnected[curr.Item1][curr.Item2] && !PacConnected[newCurr.Item1][newCurr.Item2])
                    {
                        PacConnected[newCurr.Item1][newCurr.Item2] = true;
                        stack.Push((newCurr.Item1, newCurr.Item2));
                        Console.WriteLine($"PAC connected at {newCurr.Item1} and {newCurr.Item2}");
                    }
                    if(AtlConnected[newCurr.Item1][newCurr.Item2] && PacConnected[newCurr.Item1][newCurr.Item2])
                    {
                        result.Add(new int[] { newCurr.Item1, newCurr.Item2 });
                    }
                }
            }
        }

        return result;
    }

    // we add all to a queue and we just traverse.
    // traverse in 4 directions checking for bounds and if it has been already visited before, how do we know which one to check or which we traversing? Good point.
    // traverse pacific.
    // Might just loop it in a while queue until its empty.
    //public void Traverse(int x, int y)
    //{
        
    //}
}

public class Solution
{
    private int[][] directions = new int[][] {
        new int[] { 1, 0 }, new int[] { -1, 0 },
        new int[] { 0, 1 }, new int[] { 0, -1 }
    };
    public List<List<int>> PacificAtlantic(int[][] heights)
    {
        int ROWS = heights.Length, COLS = heights[0].Length;
        bool[,] pac = new bool[ROWS, COLS];
        bool[,] atl = new bool[ROWS, COLS];

        for (int c = 0; c < COLS; c++)
        {
            Dfs(0, c, pac, heights);
            Dfs(ROWS - 1, c, atl, heights);
        }
        for (int r = 0; r < ROWS; r++)
        {
            Dfs(r, 0, pac, heights);
            Dfs(r, COLS - 1, atl, heights);
        }

        List<List<int>> res = new List<List<int>>();
        for (int r = 0; r < ROWS; r++)
        {
            for (int c = 0; c < COLS; c++)
            {
                if (pac[r, c] && atl[r, c])
                {
                    res.Add(new List<int> { r, c });
                }
            }
        }
        return res;
    }

    private void Dfs(int r, int c, bool[,] ocean, int[][] heights)
    {
        ocean[r, c] = true;
        foreach (var dir in directions)
        {
            int nr = r + dir[0], nc = c + dir[1];
            if (nr >= 0 && nr < heights.Length && nc >= 0 &&
                nc < heights[0].Length && !ocean[nr, nc] &&
                heights[nr][nc] >= heights[r][c])
            {
                Dfs(nr, nc, ocean, heights);
            }
        }
    }
}