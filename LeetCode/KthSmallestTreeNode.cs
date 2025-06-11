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
    List<int> list;
    int target;

    public int KthSmallest(TreeNode root, int k)
    {
        list = new List<int>();
        target = k;
        Traverse(root);
        return list[k - 1];
    }

    public void Traverse(TreeNode root)
    {
        if (list.Count >= target || root == null)
        {
            return;
        }
        Traverse(root.left);
        list.Add(root.val);
        Traverse(root.right);
    }
}