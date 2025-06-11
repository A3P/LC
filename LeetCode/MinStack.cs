using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MinStack
{
    public class Node
    {
        public int val;
        public Node? next;
        public int min;
    }

    Node head;

    public MinStack()
    {
    }

    public void Push(int val)
    {
        Node current = new Node();
        current.val = val;
        current.next = head;
        if(head != null)
        {
            current.min = current.val < head.min ? current.val : head.min;
        } else
        {
            current.min = current.val;
        }
        head = current;
    }

    public void Pop()
    {
        head = head.next;
    }

    public int Top()
    {
        return head.val;
    }

    public int GetMin()
    {
        return head.min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */