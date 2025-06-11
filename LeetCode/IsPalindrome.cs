using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Solution
{
    public bool IsPalindrome(string s)
    {
        Regex rgx = new Regex("[^a-zA-Z0-9]");
        string str = rgx.Replace(s, "").ToLower();
        Console.WriteLine($"str: {str}");
        if(str.Length == 0)
        {
            return true;
        }
        for (int i = 0; i <= str.Length / 2; i++)
        {
            Console.WriteLine($"Comparing {str[i]} with {str[^(i+1)]}");
            if (str[i] != str[^(i+1)]) 
            {
                return false;
            }
        }
        return true;
    }
}