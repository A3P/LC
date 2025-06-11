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
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    public bool HasCycle(ListNode head)
    {
        HashSet<int> visited = new HashSet<int>();
        while(head != null)
        {
            if(!visited.Add(head.val))
            {
                return true;
            }
            head = head.next;
        }
        return false;
    }
}