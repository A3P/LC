﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int sum = l1.val + l2.val;
        ListNode head = new ListNode(sum % 10);
        ListNode current = head;
        l1 = l1.next;
        l2 = l2.next;
        int carry = sum / 10;
        while(l1 != null || l2 != null)
        {
            sum = 0;
            if(l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }
            if(l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }
            int total = sum + carry;
            current.next = new ListNode(total % 10);
            current = current.next;
            carry = total / 10;
        }
        if(carry > 0)
        {
            current.next = new ListNode(carry);
        }
        return head;
    }
}