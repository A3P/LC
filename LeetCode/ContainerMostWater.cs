using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    int [] height;

    public int MaxArea(int[] height)
    {
        this.height = height;
        int left = 0;
        int right = height.Length - 1;

        int max = GetArea(left, right);

        int currLeft = left;
        int currRight = right;
        while(currLeft < currRight)
        {
            int area = GetArea(currLeft, currRight);
            if(area > max)
            {
                max = area;
                //Console.WriteLine($"new area total {max}, using left {currLeft}, right {currRight}");
            }
            area = GetArea(left, currRight);
            //if (area > max)
            //{
            //    right = currRight;
            //    max = area;
            //    Console.WriteLine($"new area total {max}, using left {left}, right {right}");
            //}
            if (height[currLeft] <= height[currRight])
            {
                currLeft++;
            } else
            {
                currRight--;
            }
        }
        return max;
    }

    public int GetArea(int left, int right)
    {
        int area = Math.Min(height[left], height[right]) * (right - left);
        //Console.WriteLine($"Area {area}, left {left}, right {right}");
        return area;
    }
}