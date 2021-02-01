namespace LeetCode.Trees
{
    class _208_ImplementTrie
    {
        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var node = _root;
            for (int i = 0; i < word.Length; i++)
            {
                var index = word[i] - 'a';
                if (node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }

                node = node.Children[index];
            }

            node.isEndOfWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var node = _root;

            for (int i = 0; i < word.Length; i++)
            {
                var index = word[i] - 'a';
                if (node.Children[index] == null)
                {
                   return false;
                }

                node = node.Children[index];
            }

            return node.isEndOfWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var node = _root;

            for (int i = 0; i < prefix.Length; i++)
            {
                var index = prefix[i] - 'a';
                if (node.Children[index] == null)
                {
                    return false;
                }

                node = node.Children[index];
            }

            return true;
        }

        private TrieNode _root = new TrieNode();
    }
}
