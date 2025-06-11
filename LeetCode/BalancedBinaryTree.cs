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

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Solution
{
    bool returnVal = true;
    public bool IsBalanced(TreeNode root)
    {
        MaxDepth(root);
        return returnVal;
    }

    public int MaxDepth(TreeNode root)
    {
        if (root == null || !returnVal) return 0;
        int left = MaxDepth(root.left) + 1;
        int right = MaxDepth(root.right) + 1;
        if(Math.Abs(left - right) > 1)
        {
            returnVal = false;
        }
        return left > right ? left : right;
    }
}