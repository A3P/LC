using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// definition for a node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}


public class Solution
{
    public CourseNode CopyRandomList(CourseNode head)
    {
        CourseNode dummy = new CourseNode(0);
        CourseNode currentOG = head;
        CourseNode currentCopy = dummy;
        Dictionary<CourseNode, CourseNode> dict = new Dictionary<CourseNode, CourseNode>();
        //List<Node> list = new List<Node>();
        while(currentOG != null)
        {
            //Console.WriteLine($"OG: {currentOG.val}");
            currentCopy.next = new CourseNode(currentOG.val);
            currentCopy = currentCopy.next;
            //list.Add(currentCopy);
            dict.Add(currentOG, currentCopy);
            currentOG = currentOG.next;
        }
        currentCopy = dummy.next;
        currentOG = head;
        while (currentOG != null)
        {
            if(currentOG.random == null)
            {
                currentCopy.random = null;
            } else
            {
                currentCopy.random = dict[currentOG.random];
                //Console.WriteLine($"currentCopy: {currentCopy.val} , rand: {currentCopy.random.val}");
            }
            currentOG = currentOG.next;
            currentCopy = currentCopy.next;
        }
        return dummy.next;
    }
}