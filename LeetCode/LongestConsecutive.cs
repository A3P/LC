using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length < 2) return nums.Length;
        var set = new HashSet<int>(nums);
        var maxSequence = 0;
        foreach(int num in nums)
        {
            if (!set.Contains(num - 1))
            {
                var nextInSequence = num + 1;
                var count = 1;
                while (set.Contains(nextInSequence++))
                {
                    count++;
                }
                maxSequence = Math.Max(maxSequence, count);

            }
        }
        return maxSequence;
    }
}

//public class Solution
//{
//    public int LongestConsecutive(int[] nums)
//    {
//        Dictionary<int, SortedSet<int>> dict = new();
//        foreach (int num in nums)
//        {
//            if (dict.ContainsKey(num))
//            {
//                continue;
//            }
//            SortedSet<int> adjacentSeq;
//            dict[num] = new SortedSet<int>
//            {
//                num
//            };
//            if (dict.ContainsKey(num + 1))
//            {
//                Console.WriteLine($"{num} being added to {num + 1}");
//                dict[num + 1].UnionWith(dict[num]);
//                dict[num].UnionWith(dict[num + 1]);
//            }
//            if (dict.ContainsKey(num - 1))
//            {
//                Console.WriteLine($"{num} being added to {num - 1}");
//                dict[num - 1].UnionWith(dict[num]);
//                dict[num].UnionWith(dict[num - 1]);
//                foreach (int numInSet in dict[num])
//                {
//                    Console.WriteLine($"{numInSet} is in set");
//                }
//            }
//        }
//        int count = 0;
//        foreach (SortedSet<int> set in dict.Values)
//        {
//            //Console.WriteLine($"set");
//            //foreach()
//            //{

//            //}
//            if (set.Count > count)
//            {
//                count = set.Count;
//            }
//        }
//        return count;
//    }
//}