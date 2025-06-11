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
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        return Equal(p, q);
    }

    public bool Equal(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }
        else if(p == null || q == null) 
        {
            return false;
        } else if(p.val != q.val)
        {
            return false;
        }
        if(!Equal(p.left, q.left))
        {
            return false;
        }
        if (!Equal(p.right, q.right))
        {
            return false;
        }
        return true;
    }
}