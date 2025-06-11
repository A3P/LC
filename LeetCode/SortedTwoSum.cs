using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int curr = 0;
        int compare = 1;
        while (curr < numbers.Length)
        {
            compare = curr + 1;
            while(compare < numbers.Length && numbers[compare] + numbers[curr] <= target)
            {
                if (numbers[curr] + numbers[compare] == target)
                {
                    return new int[] { curr + 1, compare + 1};
                }
                compare++;
            }
            curr++;
        }
        return new int[] { curr  + 1, compare + 1};
    }
}

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int low = 0;
        int high = numbers.Length - 1;

        while(low != high)
        {
            int result = numbers[low] + numbers[high];
            if (result == target)
            {
                break;
            } else if(result > target)
            {
                high--;
            } else
            {
                low++;
            }
        }
        return new int[] { low + 1, high + 1 };
    }
}