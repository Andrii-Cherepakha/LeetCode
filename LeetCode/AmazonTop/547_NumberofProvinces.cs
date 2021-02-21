using NUnit.Framework;

namespace LeetCode.AmazonTop
{
    class _547_NumberofProvinces
    {
        [Test]
        public void Test()
        {
            int[][] arr = new int[4][] { new int[]{ 1, 0, 0, 1 }, new int[] { 0, 1, 1, 0 }, new int[] { 0, 1, 1, 1 }, new int[] { 1, 0, 1, 1 } };

            FindCircleNum(arr);
        }
        
        public int FindCircleNum(int[][] isConnected)
        {

            uf = new int[isConnected.Length];

            // MakeSet(X)
            for (int i = 0; i < uf.Length; i++)
            {
                uf[i] = i;
            }

            int size = isConnected.Length; // m == n by definition

            for (int n = 0; n < size; n++)
                for (int m = 0; m < size; m++)
                {
                    // union
                    if (m > n && isConnected[n][m] == 1)
                    {
                        var r1 = Find(uf[n]);
                        var r2 = Find(uf[m]);
                        uf[r1] = r2;
                    }
                }

            // do not search for count of unique elements in the array !!!
            // search for count of parents !!!
            int cnt = 0;
            for (int i = 0; i < uf.Length; i++)
            {
                if (uf[i] == i) cnt++;
            }

            return cnt;
        }

        private int[] uf;

        private int Find(int x)
        {
            if (uf[x] != x) uf[x] = Find(uf[x]);
            return uf[x];
        }
    }
}
