using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> anagrams = new();
        foreach (string str in strs)
        {
            string key = String.Concat(str.OrderBy(ch => ch));
            List<string> list;
            if(anagrams.TryGetValue(key, out list)) {
                list.Add(str);
            } else
            {
                anagrams[key] = new List<string> { str };
            }
        }
        IList<IList<string>> returnList = (IList<IList<string>>)new List<IList<string>>();
        foreach (List<string> anagramList in anagrams.Values)
        {
            returnList.Add((IList<string>)anagramList);
        }
        return returnList;
    }
}
