using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Trees
{
    public class _501_FindModeBST
    {
        public int[] FindMode_dict(TreeNode root)
        {
            BuildDictionary(root);

            if (occurance.Count == 0) return new int[0];

            var max = occurance.Values.ToList().OrderByDescending(i => i).First();
            var r = occurance.Where(i => i.Value == max).Select(i => i.Key).ToList();

            return r.ToArray();
        }

        private void BuildDictionary(TreeNode root)
        {
            if (root == null) return;

            BuildDictionary(root.left);

            if (occurance.ContainsKey(root.val))
            {
                occurance[root.val]++;
            }
            else
            {
                occurance[root.val] = 1;
            }

            BuildDictionary(root.right);
        }

        private Dictionary<int, int> occurance = new Dictionary<int, int>();

        // *****************************************************************************

        //public int[] FindMode(TreeNode root)
        //{
        //    if (root == null) return new int[0];

        //    FindMaxOccur(root);
        //    previous = null;
        //    curOccur = 1;
        //    AddValue(root);

        //    return result.ToArray();
        //}

        //private void FindMaxOccur(TreeNode root)
        //{
        //    if (root == null) return;

        //    FindMaxOccur(root.left);

        //    if (previous != null)
        //    {
        //        if (previous.val == root.val)
        //        {
        //            curOccur++;
        //        }
        //        else
        //        {
        //            maxOccur = Math.Max(maxOccur, curOccur);
        //            curOccur = 1;
        //        }

        //        maxOccur = Math.Max(maxOccur, curOccur);
        //    }

        //    previous = root;

        //    FindMaxOccur(root.right);
        //}

        //private void AddValue(TreeNode root)
        //{
        //    if (root == null) return;

        //    AddValue(root.left);

        //    if (previous != null)
        //    {
        //        if (previous.val == root.val)
        //        {
        //            curOccur++;
        //        }
        //        else
        //        {
        //            if (curOccur == maxOccur)
        //            {
        //                result.Add(previous.val);
        //            }
        //            curOccur = 1;
        //        }
        //    }

        //    if (curOccur == maxOccur)
        //    {
        //        result.Add(previous.val);
        //    }

        //    previous = root;

        //    AddValue(root.right);
        //}

        //private List<int> result = new List<int>();
        //private TreeNode previous;
        //private int curOccur = 1;
        //private int maxOccur = 0;
    }
}
