using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    Dictionary<int, int> minCounts = new();

    public int CoinChange(int[] coins, int amount)
    {
        if(amount == 0) {
            return 0;
        }
        for(int i = amount -1; i >= 0; i--)
        {
            int minCount = -1;
            for(int j = 0; j < coins.Length; j++)
            {
                int sumResult = i + coins[j];
                //Console.WriteLine($"SumResult {sumResult}");
                if(sumResult == amount )
                {
                    minCount = 1;
                } else if (minCounts.ContainsKey(sumResult) && (minCount == -1 || minCounts[sumResult] + 1 < minCount))
                {
                    minCount = minCounts[sumResult] + 1;
                }
            }
            if(minCount != -1)
            {
                minCounts[i] = minCount;
            }
            //Console.WriteLine($"minCount {minCount}");
        }
        if (minCounts.ContainsKey(0))
        {
            return minCounts[0];
        }
        return -1;
    }
}