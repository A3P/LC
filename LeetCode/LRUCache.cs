using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LRUCache
{
    Dictionary<int, (int, LinkedListNode<int>)> cache = new Dictionary<int, (int, LinkedListNode<int>)>();
    LinkedList<int> list= new LinkedList<int>();
    int capactiy;

    public LRUCache(int capacity)
    {
        capactiy = capacity;
    }

    public int Get(int key)
    {
        if(cache.ContainsKey(key))
        {
            list.Remove(cache[key].Item2);
            list.AddLast(key);
            //Console.WriteLine($" new index after get :{list.Count - 1}");
            cache[key] = (cache[key].Item1, list.Last);
            return cache[key].Item1;
        } else
        {
            return -1;
        }
    }

    public void Put(int key, int value)
    {
        if(cache.ContainsKey(key))
        {
            list.Remove(cache[key].Item2);
        }
        list.AddLast(key);
        if(capactiy < list.Count) 
        {
            cache.Remove(list.First.Value);
            list.RemoveFirst();
        }
        cache[key] = (value, list.Last);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */