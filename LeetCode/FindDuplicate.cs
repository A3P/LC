using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        int slow = 0;
        int fast = 0;
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);
        Console.WriteLine($"out : {fast}");
        int newSlow = 0;
        while (newSlow != fast)
        {
            newSlow = nums[newSlow];
            fast = nums[fast];
        }
        return newSlow;
    }
}