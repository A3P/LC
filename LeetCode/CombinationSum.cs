using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public IList<IList<int>> CombinationSum(int[] nums, int target)
    {
        List<IList<int>> combinations = new();

        void CheckCombinations(List<int> combination, int sum, int index)
        {
            List<int> newCombination;
            //Console.WriteLine($"combination: {string.Join("", combination)}");
            for (int i = index; i < nums.Length; i++)
            {
                int newSum = sum + nums[i];
                //Console.WriteLine($"Newsum: {newSum}");
                if (newSum >= target)
                {
                    if (newSum == target)
                    {
                        newCombination = (List<int>)combination.ToList();
                        newCombination.Add(nums[i]);
                        //Console.WriteLine($"Adding combination: {string.Join("", newCombination)}");
                        combinations.Add(newCombination);
                    }
                }
                else
                {
                    newCombination = combination.ToList();
                    newCombination.Add(nums[i]);
                    CheckCombinations(newCombination, newSum, i);
                }
            }
        }

        CheckCombinations(new List<int>(), 0, 0);
        return combinations;

        //CheckCombinations(new List<int>(), 0, 0);
        //for (int i = 0; i < nums.Length;i++)
        //{
        //    List<int> combination = new();
        //    combination.Add(nums[i]);
        //    if (nums[i] >= target)
        //    {
        //        if (nums[i] == target)
        //        {
        //            combinations.Add(combination);
        //        }
        //    } else
        //    {
        //        CheckCombinations(combination, nums[i], i);
        //    }
        //}
    }
}

    //public void CheckCombinations(List<int> combination, int sum, int index)
    //{
    //    Console.WriteLine($"combination: {string.Join("", combination)}");
    //    for (int i = 0; i < nums.Length; i++)
    //    {
    //        List<int> combination = new();
    //        combination.Add(nums[i]);
    //        if (nums[i] >= target)
    //        {
    //            if (nums[i] == target)
    //            {
    //                combinations.Add(combination);
    //            }
    //        }
    //        else
    //        {
    //            CheckCombinations(combination, nums[i], i);
    //        }
    //    }
    //}
