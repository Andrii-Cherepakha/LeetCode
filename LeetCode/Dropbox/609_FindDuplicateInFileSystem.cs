using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Dropbox
{
    public class FindDuplicateInFileSystem
    {
        /* 
            Imagine you are given a real file system, how will you search files? DFS or BFS?

            DFS: Depth-First Search. BFS: Breadth-First Search

                The answer depends on the tree structure. If the branching factor (n) and depth (d) are high, 
                then BFS will take up a lot of memory O(d^n). For DFS, the space complexity is generally the height of the tree - O(d). 

                BFS explores neighbors first. This means that files which are located close to each other are also accessed one after another. 
                This is great e.g. for reducing HDD seek times due to space locality and is expected to be faster. 
                For SSDs, larger number of small sequential reads can be grouped into smaller number of large reads.


            If the file content is very large (GB level), how will you modify your solution?

                read the file in chunks, compute a hash (like SHA-256) incrementally

            If you can only read the file by 1kb each time, how will you modify your solution?

                a rolling hash algorithm


            What is the time complexity of your modified solution? What is the most time-consuming part and memory-consuming part of it? How to optimize?
            
        
            How to make sure the duplicated files you find are not false positive?                  

                To avoid false positives, file sizes can be compared first. 
                If the sizes match, the file hashes are compared. 
                If the hashes are identical, a byte-by-byte comparison can be performed to ensure the files are truly duplicates.
         */


        public IList<IList<string>> FindDuplicate2(string[] paths)
        {
            IList<IList<string>> result = new List<IList<string>>();

            if (paths == null || paths.Length == 0) 
            {
                return result;
            }

            Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();

            foreach (string path in paths) 
            {
                // "root/a 1.txt(abcd) 2.txt(efgh)"
                var items = path.Split(' ');
                string folder = items[0];
                for (int i=1; i < items.Length; i++)
                { 
                    int p = items[i].IndexOf('(');
                    string fileName = items[i].Substring(0, p);
                    string content = items[i].Substring(p+1, items[i].Length - p - 2);

                    if (!dict.ContainsKey(content))
                    {
                        dict[content] = new List<string>();
                    }
                    IList<string> list = dict[content];
                    list.Add(folder + "/" + fileName);
                }
            }

            foreach (string key in dict.Keys)
            {
                var value = dict[key];
                if (value.Count > 1)
                {
                    result.Add(value);
                }
            }

            return result;
        }


        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            IList <IList<string> > result = new List <IList <string>> ();
            if (paths == null || paths.Length == 0)
            {
                return result;
            }

            Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>> ();

            foreach (string path in paths)
            {
                // "root/a 1.txt(abcd) 2.txt(efgh)"
                var items = path.Split(' ');
                string folder = items[0];
                for (int i=1; i < items.Length; i++) 
                {
                    int p = items[i].IndexOf('(');
                    string fileName = items[i].Substring(0, p);
                    string content = items[i].Substring(p+1, items[i].Length - p - 2);
                    if (!dict.ContainsKey(content))
                    {
                        dict[content] = new List<string> ();
                    }
                    IList<string> list = dict[content];
                    list.Add(folder + "/" + fileName);
                }
            }

            foreach (var key in dict.Keys) 
            {
                IList<string> value = dict[key];
                if (value.Count > 1)
                {
                    result.Add(value);
                }
            }

            return result;
        }

        [Test]
        public void test()
        {
            var input = new string[] { "root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)" };
            var res = FindDuplicate2(input);
            Console.WriteLine(res.Count + " " + res);
            foreach (var item in res)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
