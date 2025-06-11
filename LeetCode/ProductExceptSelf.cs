using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] result = new int[nums.Length];
        result[0] = 1;
        int prefix = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            prefix = prefix * nums[i - 1];
            result[i] = prefix;
        }
        int postfix = 1;
        for (int i = nums.Length - 1; i > 0; i--)
        {
            postfix = postfix * nums[i];
            result[i - 1] *= postfix;
        }
        return result;
    }
}