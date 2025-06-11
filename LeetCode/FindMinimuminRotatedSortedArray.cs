using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int FindMin(int[] nums)
    {
        int upperBound = nums.Length - 1;
        int lowerBound = 0;

        while (upperBound - lowerBound > 1)
        {
            if (nums[lowerBound] < nums[upperBound])
            {
                break;
            }
            int midIndex = (lowerBound + upperBound + 1) / 2;
            if (nums[lowerBound] > nums[midIndex])
            {
                upperBound = midIndex;
            }
            else
            {
                lowerBound = midIndex;
            }
        }
        return Math.Min(nums[lowerBound], nums[upperBound]);
    }
}