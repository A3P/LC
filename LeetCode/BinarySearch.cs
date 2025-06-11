using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int lower = 0;
        int upper = nums.Length - 1;
        int index = (lower + upper) / 2;
        while (nums[index] != target)
        {
            Console.WriteLine($"Try {index}, with upper {upper} and lower {lower}");
            if (nums[index] < target)
            {
                if(lower == index)
                {
                    lower = upper;
                } else
                {
                    lower = index + 1;
                }
            } else
            {
                if (upper == index)
                {
                    upper = lower;
                } else
                {
                    upper = index - 1;
                }
            }
            index = (lower + upper) / 2;
            if(upper <= lower)
            {
                if (nums[index] != target)
                {
                    return -1;
                } else
                {
                    return index;
                }
            }
        }
        return index;
    }
}
