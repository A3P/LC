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
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    int goodOnes = 0;

    public int GoodNodes(TreeNode root)
    {
        if(root != null)
        {
            goodOnes++;
            if(root.left != null)
            {
                Traverse(root.left, root.val);
            }
            if(root.right != null)
            {
                Traverse(root.right, root.val);
            }
        }
        return goodOnes;
    }

    public void Traverse(TreeNode root, int max)
    {
        if(root.val >= max)
        {
            goodOnes++;
            max = root.val;
        }
        if (root.left != null)
        {
            Traverse(root.left, max);
        }
        if (root.right != null)
        {
            Traverse(root.right, max);
        }
    }
}