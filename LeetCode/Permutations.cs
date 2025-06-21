using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{

    List<IList<int>> ret = new List<IList<int>>();
    public IList<IList<int>> Permute(int[] nums)
    {
        List<int> numsList = new List<int>(nums);
        for (int i = 0; i < numsList.Count; i++)
        {
            // Lets
            //Console.WriteLine($"Finding permutations that start at {nums[i]}");
            ret.AddRange(Traverse(i, new List<int>(), new List<int>(numsList)));
        }
        return ret;
    }

    // Lets change the params to have index and 2 array parts, the current array and the part that still needs to be permutated, so like [1], and [2, 3]
    public List<List<int>> Traverse(int index, List<int> perm, List<int> nums)
    {
        //List<int> numsCopy = new List<int>(nums);
        int num = nums[index];
        nums.RemoveAt(index);
        perm.Add(num);
        List<List<int>> ret = new List<List<int>>();
        if(nums.Count == 0)
        {
            //Console.WriteLine($"Base {num}");
            ret.Add(perm);
        } else
        {
            for (int i = 0; i < nums.Count; i++)
            {
                //Console.WriteLine($"i {nums[i]}");
                ret.AddRange(Traverse(i, new List<int>(perm), new List<int>(nums)));
            }
        }
        return ret;
    }
}