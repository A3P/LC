public class Trie
{
    private TrieNode[] nodes;
    private const byte NUM_OF_LETTERS = 26;
    private const int INTEGER_OFFSET = 65;
    //private SortedSet<string> set;

    public Trie()
    {
        //set = new SortedSet<string>();
        nodes = new TrieNode[NUM_OF_LETTERS];
    }

    public void Insert(string word)
    {
        //set.Add(word);
        TrieNode[] trieNodes = nodes;
        TrieNode? curr = null;
        foreach(char letter in word)
        {
            int index = char.ToUpper(letter) - INTEGER_OFFSET;
            //Console.WriteLine($"Found {letter} at index {index}");
            if (trieNodes[index] == null)
            {
                trieNodes[index] = new TrieNode();
            }
            curr = trieNodes[index];
            trieNodes = trieNodes[index].nodes;
        }
        if(curr != null)
        {
            curr.endOfWord = true;
            //Console.WriteLine($"Setting endOfWord {curr.endOfWord}");
        }
    }

    public bool Search(string word)
    {
        TrieNode[] trieNodes = nodes;
        bool endOfWord = false;
        foreach (char letter in word)
        {
            int index = char.ToUpper(letter) - INTEGER_OFFSET;
            if (trieNodes[index] == null)
            {
                return false;
            }
            endOfWord = trieNodes[index].endOfWord;
            trieNodes = trieNodes[index].nodes;
        }
        return endOfWord;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode[] trieNodes = nodes;
        foreach (char letter in prefix)
        {
            int index = char.ToUpper(letter) - INTEGER_OFFSET;
            if (trieNodes[index] == null)
            {
                return false;
            }
            trieNodes = trieNodes[index].nodes;
        }
        return true;
    }

     public class TrieNode
    {
        public TrieNode[] nodes;
        public bool endOfWord = false;

        public TrieNode()
        {
            nodes = new TrieNode[NUM_OF_LETTERS];
        }
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */