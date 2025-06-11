

using System.ComponentModel.Design.Serialization;

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
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        
        return Traverse(root, subRoot);
    }

    public bool Traverse(TreeNode root, TreeNode subRoot)
    {
        //Console.WriteLine($"Traverse Root: {root.val}, {subRoot.val}");
        if (IsSame(root, subRoot))
        {
            return true;
        }
        if(root.left != null)
        {
            if (Traverse(root.left, subRoot))
            {
                return true;
            }
        }
        if (root.right != null)
        {
            if (Traverse(root.right, subRoot))
            {
                return true;
            }
        }
        return false;
    }


    public bool IsSame(TreeNode root, TreeNode subRoot)
    {
        if(root == null || subRoot == null)
        {
            if(subRoot == root)
            {
                return true;
            }
            return false;
        }
        if(root.val != subRoot.val)
        {

            return false;
        }
        return (IsSame(root.left, subRoot.left) && IsSame(root.right, subRoot.right));
    }
}



public class Solution
{
    /*    public class TreeNode
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
        }*/

    TreeNode startingNode = null;

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {

        if(!FindStartingNode(root, subRoot)) {
            return false;
        }
        Console.WriteLine($"{startingNode.val}");
        return HasChildren(startingNode, subRoot);
    }
    
    public bool FindStartingNode(TreeNode root, TreeNode subTree)
    {
        if (root == null)
        {
            return false;
        }
        if (root.val == subTree.val)
        {
            startingNode = root;
            return true;
        }
        return (FindStartingNode(root.left, subTree) || FindStartingNode(root.right, subTree));
    }

    public bool HasChildren(TreeNode root, TreeNode subTree)
    {
        Console.WriteLine($"Eval {root.val} - {subTree.val}");
        if(root.val != subTree.val) 
        {
            return false;
        }
        // left
        Console.WriteLine($"left");
        if (subTree.left == null || root.left == null)
        {
            if(root.left != null || subTree.left != null)
            {
                return false;
            }
        } else if (!HasChildren(root.left, subTree.left)) {
            return false;
        }
        // right
        Console.WriteLine($"right");
        if (subTree.right == null || root.right == null)
        {
            if (root.right != null ||subTree.right != null)
            {
                return false;
            }
        }
        else if (!HasChildren(root.right, subTree.right)) {
            return false;
        }

        return true;
    }
}