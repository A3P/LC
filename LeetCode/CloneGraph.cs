using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution
{
    public Node CloneGraph(Node node)
    {
        Dictionary<int, Node> originals = new();
        Dictionary<int, Node> clones = new();
        Queue<Node> queue = new();
        if (node != null)
        {
            queue.Enqueue(node);
            originals.Add(node.val, node);
            clones.Add(node.val, new Node(node.val));
            while (queue.Count > 0)
            {
                Node curr = queue.Dequeue();
                Node clone = clones[curr.val];
                foreach (Node neighbor in curr.neighbors)
                {
                    if (!originals.ContainsKey(neighbor.val))
                    {
                        queue.Enqueue(neighbor);
                        originals.Add(neighbor.val, neighbor);
                        clones.Add(neighbor.val, new Node(neighbor.val));
                        Console.WriteLine($"Adding {neighbor.val}");
                    }

                    clone.neighbors.Add(clones[neighbor.val]);
                }
            }
            return clones[node.val];
        }
        return node;
    }
}