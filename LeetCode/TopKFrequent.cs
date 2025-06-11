using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class TopKFrequentSolution
    {
        //public int[] TopKFrequent(int[] nums, int k)
        //{
        //    Dictionary<int, int> numCount = new();
        //    int[] returnValues = new int[k];
        //    foreach(int i in nums)
        //    {
        //        if(numCount.ContainsKey(i))
        //        {
        //            numCount[i]++;
        //        } else
        //        {
        //            numCount[i] = 1;
        //        }
        //    }
        //    var sortedDic = from entry in numCount orderby entry.Value descending select entry;
        //    for (int i = 0; i < k; i++)
        //    {
        //        returnValues[i] = sortedDic.ElementAt(i).Key;
        //    }
        //        return returnValues;
        //}
        
        public int[] TopKFrequent(int[] nums, int k)
        {
            int[] result = new int[k];
            List<int>[] bucketSort = new List<int>[nums.Length + 1];
            Dictionary<int, int> frequencyMapping = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if (frequencyMapping.ContainsKey(nums[i]))
                {
                    frequencyMapping[nums[i]] += 1;
                } else
                {
                    frequencyMapping.Add(nums[i], 1);
                }
            }
            foreach(KeyValuePair<int, int> pair in frequencyMapping)
            {
                if (bucketSort[pair.Value] != null)
                {
                    bucketSort[pair.Value].Add(pair.Key);
                } else
                {
                    bucketSort[pair.Value] = new List<int> { pair.Key };
                }
            }
            int count = 0;
            for(int i = nums.Length; i >= 0; i--)
            {
                if(bucketSort[i] != null)
                {
                    foreach(int num in bucketSort[i])
                    {
                        result[count++] = num;
                        if(count == k)
                        {
                            return result;
                        }
                    }
                }
            }
            return result;
        }
    }
}
