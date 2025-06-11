using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    string s;
    string longest = "";
    public string LongestPalindrome(string s)
    {
        this.s = s;
        for (int i = 0; i < s.Length; i++)
        {
            string currIndexLongest = GetLongest(i);
            if (currIndexLongest.Length > longest.Length)
            {
                longest = currIndexLongest;
            }
        }
        if(longest.Length == 0)
        {
            return s[0].ToString();
        }
        return longest;
    }

    private string GetLongest(int index)
    {
        //Console.WriteLine($"Checking index {index}");
        string maxString = "";
        string currString = "";
        // bool isPalin = true;
        int l = index - 1;
        int r = index + 1;
        // while(l >= 0 && r < s.Length) {
        //     Console.WriteLine($"index {index} l: {l} r: {r}");
        //     if(s[l] == s[r]) {
        //         Console.WriteLine($"Matched l: {l} r: {r} for Index{index}");
        //         currString = s.Substring(l, r);
        //         l--;
        //         r++;
        //     } else {
        //         break;
        //     }
        // }
        currString = CheckLongest(l, r);
        maxString = currString.Length > maxString.Length ? currString : maxString;
        //Console.WriteLine($"MaxString {maxString}");

        l = index - 1;
        r = index;
        currString = CheckLongest(l, r);
        maxString = currString.Length > maxString.Length ? currString : maxString;
        //Console.WriteLine($"MaxString {maxString}");

        l = index;
        r = index + 1;
        currString = CheckLongest(l, r);
        maxString = currString.Length > maxString.Length ? currString : maxString;
        //Console.WriteLine($"MaxString {maxString}");

        return maxString;
    }

    private string CheckLongest(int l, int r)
    {
        string currString = "";
        int currL = l;
        int currR = r;
        while (currL >= 0 && currR < s.Length)
        {
            //Console.WriteLine($" l: {currL} r: {currR}");
            if (s[currL] == s[currR])
            {
                //Console.WriteLine($"Matched l: {currL} r: {currR}");
                currString = s.Substring(currL, currR-currL+1);
                currL--;
                currR++;
            }
            else
            {
                break;
            }
        }
        return currString;
    }
}