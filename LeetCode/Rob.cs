using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    int[] maxArray;
    //int maxVal;

    public int Rob(int[] nums)
    {
        maxArray = new int[nums.Length];

        maxArray[0] = nums[0];
        //maxVal = nums[0];

        if (nums.Length > 1) {
            maxArray[1] = nums[0] > nums[1] ? nums[0] : nums[1]; 
        }
        for(int i = 2;i < nums.Length;i++)
        {
            int currentMax = nums[i] + maxArray[i - 2];
            maxArray[i] = maxArray[i - 1] > currentMax ? maxArray[i - 1] : currentMax;
            Console.WriteLine($"maxArray {i} : {maxArray[i]}");
        }
        Console.WriteLine($"maxVal num.length: {maxArray[nums.Length-1]}");
        return maxArray[maxArray.Length - 1];
    }
}