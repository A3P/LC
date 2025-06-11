using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        return TraverseTree(root).Item2;
    }

    public (int, int) TraverseTree(TreeNode root)
    {
        // return values: (height, diameter)
        if (root == null)
        {
            return (-1, 0);
        }
        else
        {
            (int, int) left = TraverseTree(root.left);
            Console.WriteLine($"left: {left}");
            (int, int) right = TraverseTree(root.right);
            int height = Math.Max(left.Item1, right.Item1) + 1;
            // the missing ingredient
            int maxPreviousD = Math.Max(left.Item2, right.Item2);
            int diameter = Math.Max(left.Item1 + right.Item1 + 2, maxPreviousD);
            Console.WriteLine($" l:{left.Item1} r: {right.Item1}");
            Console.WriteLine($"Evaluating Node: {root.val}, height: {height}, D: {diameter}");
            return (height, diameter);
        }
    }
}