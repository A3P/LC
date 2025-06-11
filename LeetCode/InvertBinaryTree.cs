using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if(root != null)
        {
            InvertTree(root.left);
            InvertTree(root.right);
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
        }
        return root;
    }
}