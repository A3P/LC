using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        List<TreeNode> pList = new();
        List<TreeNode> qList = new();
        AddPathToList(root, p, pList);
        AddPathToList(root, q, qList);
        return pList.Intersect(qList).Last();
    }

    public void AddPathToList(TreeNode root, TreeNode node, List<TreeNode> list)
    {
        TreeNode current = root;
        while (current.val != node.val)
        {
            Console.WriteLine($"current {current.val}");
            list.Add(current);
            if(node.val < current.val)
            {
                current = current.left;
            } else
            {
                current = current.right;
            }
        }
        list.Add(current);
    }
}