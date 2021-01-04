using System;

namespace LeetCode.Arrays
{
    class _1491_AverageSalaryExcludingMinimumMaximumSalary
    {
        public double Average(int[] salary)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            double sum = 0;

            foreach (int value in salary)
            {
                sum += value;
                max = Math.Max(value, max);
                min = Math.Min(value, min);
            }

            sum = sum - max - min;
            return sum / (salary.Length - 2);
        }
    }
}
