using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LeetCode
{
    public class AsyncAwait
    {
        public IEnumerable<int> GetInt()
        {
            for (int i=0; i < 10; i++)
            {
                yield return i;
                Thread.Sleep(200);
            }
        }

        public async IAsyncEnumerable<int> GetIntAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
                await Task.Delay(200);
            }
        }

        [Test]
        public void test()
        {
            foreach (var i in GetInt())
            {
                Console.WriteLine(i);
            }
            foreach (var i in GetInt())
            {
                Console.WriteLine(i);
            }
        }

        [Test]
        public async Task testAsync()
        {
            await foreach (var i in GetIntAsync())
            {
                Console.WriteLine(i);
            }
            await foreach (var i in GetIntAsync())
            {
                Console.WriteLine(i);
            }
        }

        private int iteratorSync = 0;
        private int iteratorAsync = 0;

        public int WaitAndReturn(int delay)
        {
            Thread.Sleep(delay);
            return iteratorSync++;
        }

        public async Task<int> WaitAndReturnAsync(int delay)
        {
            await Task.Delay(delay);
            return iteratorAsync++;
        }

        [Test]
        public void testSeveral()
        {
            Console.WriteLine(WaitAndReturn(200));
            Console.WriteLine(WaitAndReturn(300));
            Console.WriteLine(WaitAndReturn(400));
            Console.WriteLine(WaitAndReturn(300));
            Console.WriteLine(WaitAndReturn(200));
            Console.WriteLine(WaitAndReturn(100));
        }

        [Test]
        public async Task testSeveralAsync()
        {
            Console.WriteLine(await WaitAndReturnAsync(200));
            Console.WriteLine(await WaitAndReturnAsync(300));
            Console.WriteLine(await WaitAndReturnAsync(400));
            Console.WriteLine(await WaitAndReturnAsync(300));
            Console.WriteLine(await WaitAndReturnAsync(200));
            Console.WriteLine(await WaitAndReturnAsync(100));
        }
    }
}
