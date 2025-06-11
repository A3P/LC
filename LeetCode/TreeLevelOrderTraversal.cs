using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Definition for a binary tree node.
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }
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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> returnList = (IList<IList<int>>) new List<IList<int>>();
        Traverse(root, 0, returnList);
        return returnList;
    }

    public IList<IList<int>> Traverse(TreeNode root, int level, IList<IList<int>> returnList)
    {
        if (root == null)
        {
            return returnList;
        }
        if (returnList.Count() <= level)
        {
            returnList.Add(new List<int> { root.val });
        } else
        {
            returnList[level].Add(root.val);
        }
        Traverse(root.left, level + 1, returnList);
        Traverse(root.right, level + 1, returnList);
        return returnList;
    }
}