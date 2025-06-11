using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    List<IList<int>> ret = new();
    int[] nums;

    public IList<IList<int>> Subsets(int[] nums)
    {
        this.nums = nums;
        AddToSet(new List<int>(), -1);
        return ret;
    }

    public void AddToSet(List<int> set, int index)
    {
        ret.Add(set);
        //Console.WriteLine($"set added");
        //foreach(int num in set)
        //{
        //    Console.WriteLine($"num: {num}");
        //}
        for(int i = index+1; i < nums.Length; i++)
        {
            List<int> newList = new List<int>(set);
            newList.Add(nums[i]);
            AddToSet(newList, i);
        }
    }
}