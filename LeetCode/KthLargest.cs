using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class KthLargest
{
    PriorityQueue<int, int> data = new PriorityQueue<int, int>();
    int k;

    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        foreach (var num in nums)
            Add(num);
    }

    public int Add(int val)
    {
        data.Enqueue(val, val);

        if (data.Count > k)
            data.Dequeue();

        return data.Peek();
    }
}

//public class KthLargest
//{
//    SortedList<int, int> list;
//    int target;
//    public KthLargest(int k, int[] nums)
//    {
//        list = new SortedList<int, int>(Comparer<int>.Create(
//            (num1, num2) => -num1.CompareTo(num2)
//            ));
//        target = k;
//        foreach(int num in nums)
//        {
//            if (list.ContainsKey(num))
//            {
//                list[num]++;
//            }
//            else
//            {
//                list[num] = 1;
//            }
//        }
//    }

//    public int Add(int val)
//    {
//        if(list.ContainsKey(val))
//        {
//            list[val]++;
//        } else
//        {
//            list[val] = 1;
//        }
//        int count = 0;
//        int index = 0;
//        while (count < target)
//        {
//            //Console.WriteLine($"{list.Keys[index]} with : {list.Values[index]}");
//            count += list.Values[index++];
//        }
//        return list.Keys[--index];
//    }
//}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */