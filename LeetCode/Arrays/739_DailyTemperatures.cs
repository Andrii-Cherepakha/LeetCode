namespace LeetCode.Arrays
{
    class _739_DailyTemperatures
    {
        public int[] DailyTemperatures(int[] T)
        {
            var result = new int[T.Length];

            for (int i = T.Length - 1; i >= 0; i--)
            {
                int j = i + 1;
                while (j < T.Length) 
                {
                    if (T[j] > T[i])
                    {
                        result[i] = j - i;
                        break;
                    }
                    if (result[j] == 0) break;
                    j = j + result[j];
                }
            }

            return result;
        }



        public int[] DailyTemperatures_TimeLimitExceeded(int[] T)
        {
            var result = new int[T.Length];

            for (int i = 0; i < T.Length; i++)
            {
                //result[i] = 0;
                int j = i + 1;
                while (j < T.Length)
                {
                    if (T[j] > T[i])
                    {
                        result[i] = j - i;
                        break;
                    }
                    j++;
                }
            }

            return result;
        }
    }
}