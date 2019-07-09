using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.Other
{
    class CCISumOfCubes
    {
        [Test]
        public void SumOfCubes()
        {
            int n = 1000;

            var hashTable = new Dictionary<int, int[]>(); // sum, index1, index2

            for (int i = 0; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    var key = i*i*i + j*j*j;

                    if (hashTable.ContainsKey(key))
                    {
                        var value = hashTable[key];
                        int v0 = value[0] * value[0] * value[0];
                        int v1 = value[1] * value[1] * value[1];
                        Console.WriteLine($"{i}^3 + {j}^3 = {i * i * i} + {j * j * j} = {key} = {value[0]}^3 + {value[1]}^3 = {v0} + {v1}");
                    }
                    else
                    {
                        hashTable[key] = new int[]{i, j};
                    }
                }
            }

        }
    }
}
