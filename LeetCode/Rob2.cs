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
        if(nums.Length == 1)
        {
            return nums[0];
        }
        int[] arr1 = nums[0..^1];
        int[] arr2 = nums[1..];
        //Console.WriteLine($"len {arr1.Length}");
        int maxArr1 = Rob2(arr1);
        int maxArr2 = Rob2(arr2);
        //int max = maxArr1 > maxArr2 : ]
        
        return int.Max(maxArr1, maxArr2);
    }

    public int Rob2(int[] nums)
    {
        maxArray = new int[nums.Length];

        maxArray[0] = nums[0];
        //maxVal = nums[0];

        if (nums.Length > 1)
        {
            maxArray[1] = nums[0] > nums[1] ? nums[0] : nums[1];
        }
        for (int i = 2; i < nums.Length; i++)
        {
            int currentMax = nums[i] + maxArray[i - 2];
            maxArray[i] = maxArray[i - 1] > currentMax ? maxArray[i - 1] : currentMax;
            //Console.WriteLine($"maxArray {i} : {maxArray[i]}");
        }
        //Console.WriteLine($"maxVal num.length: {maxArray[nums.Length - 1]}");
        return maxArray[maxArray.Length - 1];
    }
}