using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public bool CanJump(int[] nums)
    {
        int max = 0;
        int curr = 0;
        bool[] visited = new bool[nums.Length];

        do
        {
            //Console.WriteLine($"curr: {curr}");
            int maxJumpIndex = curr + nums[curr];
            if (maxJumpIndex >= nums.Length - 1)
            {
                return true;
            } else if(maxJumpIndex > max)
            {
                max = maxJumpIndex;
                curr = max;
            } else
            {
                visited[curr] = true;
                while (visited[curr] && curr > 0)
                {
                    curr --;
                }
            }
        } while (curr > 0);
        return false;
    }
}