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
    public void ReorderList(ListNode head)
    {
        List<ListNode> list = new List<ListNode>();
        int count = 0;
        while (head != null)
        {
            list.Add(head);
            //Console.WriteLine($"Add to list: {head.val}");
            head = head.next;
        }
        int start = 0;
        int end = list.Count - 1;
        ListNode dummy = new ListNode();
        ListNode current = dummy;
        while(start <= end)
        {
            //Console.WriteLine($"start: {list[start].val}");
            //Console.WriteLine($"end: {list[end].val}");
            current.next = list[start++];
            current = current.next;
            if(end != start)
            {
                current.next = list[end--];
                current = current.next;
            }
        }
        current.next = null;
    }
}