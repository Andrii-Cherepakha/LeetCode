namespace LeetCode.Trees
{
    public class TrieNode
    {
        private const int AlphabetSize = 26;

        public TrieNode[] Children = new TrieNode[AlphabetSize];
        public bool isEndOfWord;
    }
}
