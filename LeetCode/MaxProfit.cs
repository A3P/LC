using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int lowest = prices[0];
        int[] difference = new int[prices.Length];
        int max = 0;
        
        for(int i = 0; i < prices.Length;i++)
        {
            if (prices[i] < lowest)
            {
                lowest = prices[i];
            }
            difference[i] = prices[i] - lowest;
            if (difference[i] > max)
            {
                max = difference[i];
            }
        }
        return max;
    }
}