using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        foreach (int stone in stones)
        {
            pq.Enqueue(stone, stone);
        }
        while (pq.Count > 1)
        {
            int dq1 = pq.Dequeue();
            int dq2 = pq.Dequeue();
            int difference = dq1 - dq2;
            //Console.WriteLine($"DQ1-DQ2: {dq1} - {dq2}, diff: {difference} ");
            if(difference > 0)
            {
                pq.Enqueue(difference, difference);
            }
        }
        int last = pq.Dequeue();
        return last;
    }
}