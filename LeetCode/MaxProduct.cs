using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Solution
{
    Dictionary<(int, int), int> dict = new();

    public int MaxProduct(int[] nums)
    {
        for(int i =0; i<nums.Length; i++)
        {
            if(!dict.ContainsKey((i, i) ))
            {
                dict[(i, i)] = nums[i];
            }
            for(int j = i; j< nums.Length;j++)
            {
                int totalProduct;
                if(dict.ContainsKey( ( i, j) ))
                {
                    totalProduct = dict[(i, j)];
                }
            }
        }
    }
}