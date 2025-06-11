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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode newHead = null;
        ListNode tail = newHead;
        while (list1 != null || list2 != null)
        {
            ListNode nextNode;
            if (list1 == null)
            {
                nextNode = list2;
                list2 = list2.next;
            }
            else if (list2 == null)
            {
                nextNode = list1;
                list1 = list1.next;
            }
            else if(list1.val > list2.val)
            {
                nextNode = list2;
                list2 = list2.next;
            } 
            else
            {
                nextNode = list1;
                list1 = list1.next;
            }
            if (newHead == null)
            {
                newHead = nextNode;
                tail = newHead;
            }
            else
            {
                tail.next = nextNode;
                tail = nextNode;
            }
        }
        return newHead;
    }
}