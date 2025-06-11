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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        TreeNode root = new TreeNode(preorder[0]);
        //Console.WriteLine($"preorder {preorder[0]}");
        if (preorder.Length > 1)
        {
            // Add conditional for going left or right, how do we know if need left or right subtree?
            int inorderIndex = 0;
            while (inorder[inorderIndex] != preorder[0])
                inorderIndex++;
            //Console.WriteLine($"InorderIndex {inorderIndex}");
            if(inorderIndex > 0)
            {
                root.left = BuildTree(preorder[1..(inorderIndex+1)], inorder[..inorderIndex]);
            }
            if (inorderIndex < inorder.Length-1)
            {
                root.right = BuildTree(preorder[(inorderIndex+1)..], inorder[(inorderIndex+1)..]);
            }
        }
        return root;
    }
}


//public class Solution
//{
//    private int[] preorder;
//    private int[] inorder;

//    public TreeNode BuildTree(int[] preorder, int[] inorder)
//    {
//        this.preorder = preorder;
//        this.inorder = inorder;
//        int inOrderIndex = 0;
//        while(inorder[inOrderIndex] != preorder[0])
//            inOrderIndex++;
//        return Traverse(0, inOrderIndex); 
//    }

//    public TreeNode Traverse(int rootPreorderIndex, int rootInorderIndex)
//    {
//        Console.WriteLine($"root: {preorder[rootPreorderIndex]}, preorderIndex {rootPreorderIndex} rootInorderIndex {rootInorderIndex}");
//        TreeNode root = new TreeNode(this.preorder[rootPreorderIndex]);
//        // has left side
//        int inOrderIndex = 0;
//        int leftIndex = -1;
//        if( rootInorderIndex > rootPreorderIndex)
//        {
//            leftIndex = rootPreorderIndex + 1;
//            while (inorder[inOrderIndex] != preorder[leftIndex])
//                inOrderIndex++;
//            Traverse(leftIndex, inOrderIndex);
//        }

//        int rightIndex = rootInorderIndex++;
//        Console.WriteLine($"root: {preorder[rootPreorderIndex]} left {leftIndex} right {rightIndex }");
//        return root;
//    }
//}