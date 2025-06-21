using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//public class Solution
//{
//    public int MinEatingSpeed(int[] piles, int h)
//    {
//        Array.Sort(piles);
//        Hashtable hash = new Hashtable();
//        int total = 0;
//        // # of bananas loop
//        int i = 0;
//        Console.WriteLine($"MaxValue: {piles[piles.Length-1]}");
//        //do
//        //{
//        //    i++;
//        //    total = 0;
//        //    // pile Loop
//        //    Console.WriteLine($"Eating {i} nanners");
//        //    for (int j = 0; j < piles.Length; j++)
//        //    {
//        //        // Mathmatical ceiling function
//        //        int hours = (piles[j] + i - 1) / i;
//        //        total += hours;
//        //        Console.WriteLine($"Total: {total}, {j}pile with banan:{piles[j]}, at {hours} hours");
//        //    }
//        //} while (total > h);
//        return i;
//    }
//}

//public class Solution
//{
//    public int MinEatingSpeed(int[] piles, int h)
//    {
//        int lowerBound = 1;
//        int upperBound = 0;
//        foreach(int pile in piles)
//        {
//            if(pile > upperBound)
//            {
//                upperBound = pile;
//            }
//        }
//        Console.WriteLine($"upperBound {upperBound}");


//        int hours = 0;
//        int speed = (upperBound + lowerBound) / 2;
//        while (speed != lowerBound || h != hours)
//        {
//            hours = 0;
//            speed = (upperBound + lowerBound) / 2;
//            Console.WriteLine($"speed {speed}, using lowerbound {lowerBound}, upper {upperBound}");

//            for (int i = 0; i < piles.Length; i++)
//            {
//                hours += piles[i] / speed;
//                if (piles[i] % speed > 0)
//                {
//                    hours += 1;
//                }
//                Console.WriteLine($" pile {piles[i]}, in total hours {hours}");
//            }
//            if(hours > h)
//            {
//                lowerBound = speed + 1;
//            } else
//            {
//                upperBound = speed - 1; 
//            }
//        }
//        return speed;
//    }
//}

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int l = 1;
        int r = piles.Max();
        int res = r;

        while (l <= r)
        {
            int k = (l + r) / 2;

            long totalTime = 0;
            foreach (int p in piles)
            {
                totalTime += (int)Math.Ceiling((double)p / k);
            }
            if (totalTime <= h)
            {
                res = k;
                r = k - 1;
            }
            else
            {
                l = k + 1;
            }
        }
        return res;
    }
}