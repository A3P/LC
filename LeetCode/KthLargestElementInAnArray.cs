using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

        foreach(int num in nums)
        {
            pq.Enqueue(num, num);
        }
        int curr = 0;
        for(int i =0; i< k;i++)
        {
            curr = pq.Dequeue();
            //Console.WriteLine($"num {curr}");
        }
        return curr;
    }
}