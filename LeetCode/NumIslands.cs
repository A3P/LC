using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Solution
{

    private Queue<(int, int)> landQueue = new ();
    private Queue<(int, int)> waterQueue = new ();
    private int numIslands = 0;
    
    public int NumIslands(char[][] grid)
    {
        (int, int) coordinates;
        bool[,] visited = new bool[grid.Length, grid[0].Length];
        (grid[0][0] == '1' ? landQueue : waterQueue).Enqueue((0, 0));
        while(landQueue.Count + waterQueue.Count > 0) {
            if(landQueue.Count> 0) 
                numIslands++;
            while(landQueue.Count > 0) 
            {
                coordinates = landQueue.Dequeue();
                // Console.WriteLine($"landQueue at {coordinates.Item1}, {coordinates.Item2}");
                (int,int) southCoordinates = (coordinates.Item1+1, coordinates.Item2);
                if(grid.Length > southCoordinates.Item1 && !visited[southCoordinates.Item1,southCoordinates.Item2]) {
                    visited[southCoordinates.Item1,southCoordinates.Item2] = true;
                    if(grid[southCoordinates.Item1][southCoordinates.Item2] == '1') 
                    {
                        landQueue.Enqueue((southCoordinates.Item1, southCoordinates.Item2));
                    } else {
                        waterQueue.Enqueue((southCoordinates.Item1, southCoordinates.Item2));
                    }
                }
                (int,int) eastCoordinates = (coordinates.Item1, coordinates.Item2+1);
                if(grid[0].Length > eastCoordinates.Item2 && !visited[eastCoordinates.Item1,eastCoordinates.Item2]) {
                    visited[eastCoordinates.Item1,eastCoordinates.Item2] = true;
                    if(grid[eastCoordinates.Item1][eastCoordinates.Item2] == '1') 
                    {
                        landQueue.Enqueue((eastCoordinates.Item1, eastCoordinates.Item2));
                    } else {
                        waterQueue.Enqueue((eastCoordinates.Item1, eastCoordinates.Item2));
                    }
                }
                (int,int) westCoordinates = (coordinates.Item1, coordinates.Item2-1);
                if(grid[0].Length > westCoordinates.Item2 && westCoordinates.Item2 >= 0 && !visited[westCoordinates.Item1,westCoordinates.Item2]) {
                    visited[westCoordinates.Item1,westCoordinates.Item2] = true;
                    if(grid[westCoordinates.Item1][westCoordinates.Item2] == '1') 
                    {
                        landQueue.Enqueue((westCoordinates.Item1, westCoordinates.Item2));
                    } else {
                        waterQueue.Enqueue((westCoordinates.Item1, westCoordinates.Item2));
                    }
                }
                (int,int) northCoordinates = (coordinates.Item1-1, coordinates.Item2);
                if(grid.Length > northCoordinates.Item1 && northCoordinates.Item1 >= 0 &&  !visited[northCoordinates.Item1,northCoordinates.Item2]) {
                    visited[northCoordinates.Item1,northCoordinates.Item2] = true;
                    if(grid[northCoordinates.Item1][northCoordinates.Item2] == '1') 
                    {
                        landQueue.Enqueue((northCoordinates.Item1, northCoordinates.Item2));
                    } else {
                        waterQueue.Enqueue((northCoordinates.Item1, northCoordinates.Item2));
                    }
                }
            }
            if(waterQueue.Count > 0) {
                coordinates = waterQueue.Peek();
                // Console.WriteLine($"waterQueue at {coordinates.Item1}, {coordinates.Item2}");
                (int,int) yCoordinates = (coordinates.Item1+1, coordinates.Item2);
                if(grid.Length > yCoordinates.Item1 && !visited[yCoordinates.Item1,yCoordinates.Item2]) {
                    visited[yCoordinates.Item1,yCoordinates.Item2] = true;
                    if(grid[yCoordinates.Item1][yCoordinates.Item2] == '1') 
                    {
                        landQueue.Enqueue((yCoordinates.Item1, yCoordinates.Item2));
                        continue;
                    } else {
                        waterQueue.Enqueue((yCoordinates.Item1, yCoordinates.Item2));
                    }
                }
                (int,int) eastCoordinates = (coordinates.Item1, coordinates.Item2+1);
                if(grid[0].Length > eastCoordinates.Item2 && !visited[eastCoordinates.Item1,eastCoordinates.Item2]) {
                    visited[eastCoordinates.Item1,eastCoordinates.Item2] = true;
                    if(grid[eastCoordinates.Item1][eastCoordinates.Item2] == '1') 
                    {
                        landQueue.Enqueue((eastCoordinates.Item1, eastCoordinates.Item2));
                    } else {
                        waterQueue.Enqueue((eastCoordinates.Item1, eastCoordinates.Item2));
                    }
                }
                waterQueue.Dequeue();
            }
        }
        return numIslands;
    }
}