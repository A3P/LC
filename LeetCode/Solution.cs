using System.Linq;

namespace LeetCode
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> indexMapping = new();
            int index1 = 0; int index2 = 1;

            for (int i = 0; i < nums.Count(); i++)
            {
                int difference = target - nums[i];
                if (indexMapping.ContainsKey(nums[i]))
                {
                    index1 = indexMapping[nums[i]];
                    index2 = i;
                    break;
                }
                if(!indexMapping.ContainsKey(difference))
                {
                    indexMapping.Add(difference, i);
                }
            }
            return new int[] { index1, index2 };
        }
    }
}