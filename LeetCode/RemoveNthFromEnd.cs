using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode cur = head;
        int cacheSize = n + 1;
        ListNode[] nodes = new ListNode[cacheSize];
        int count = 1;

        while(cur != null)
        {
            nodes[count % cacheSize] = cur;
            //Console.WriteLine(cur.val);
            cur = cur.next;
            count += 1;
        }
        if (n == 1)
        {
            if(head == nodes[(count - n) % cacheSize])
            {
                return null;
            } else
            Console.WriteLine($"Changing next for {nodes[(count - n - 1) % cacheSize].val} node");
            nodes[(count - n - 1) % cacheSize].next = null;
            return head;
        }
        if(head == nodes[(count - n) % cacheSize])
        {
            return nodes[(count - n + 1) % cacheSize];
        }
        Console.WriteLine($"Deleting {nodes[(count - n) % cacheSize].val} node");
        nodes[(count - n - 1) % cacheSize].next = nodes[(count - n + 1) % cacheSize];
        return head;
    }
}