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

 public class ListNode
{
     public int val;
     public ListNode next;
     public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode nextNode = head.next;
        ListNode prevNode = head;
        ListNode currentNode = nextNode;
        while(nextNode != null)
        {
            currentNode = nextNode;
            nextNode = currentNode.next;
            currentNode.next = prevNode;
            if(head == prevNode)
            {
                prevNode.next = null;
            }
        }
        return currentNode;
    }
}

public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if(head == null)
        {
            return head;
        }
        ListNode nextHead = head.next;
        while (nextHead != null)
        {
            ListNode temp = nextHead.next;
            if(head.next == nextHead)
            {
                head.next = null;
            }
            nextHead.next = head;
            head = nextHead;
            nextHead = temp;
        }
        return head;
    }
}