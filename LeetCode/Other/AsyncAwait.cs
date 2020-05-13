using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.Other
{
    public class AsyncAwait
    {
        [Test]
        public void AsyncAwaitTest()
        {
            TryCatchUsual();
            TryCatchAwait();
            TryCatchReturnResult();
        }

        [Test]
        public async Task ExecutionTest()
        {
            var x = ExecutionUsual();
            Console.WriteLine($"ExecutionUsual result: {x.Result}");

            var a = await ExecutionAwait();
            Console.WriteLine($"ExecutionAwait result: {a}");

            var r = ExecutionReturnResult();
            Console.WriteLine($"ExecutionReturnResult result: {r}");
        }

        public Task<string> ExecutionUsual()
        {
            return DoSomeWorkAsync();
        }

        public async Task<string> ExecutionAwait()
        {
            return await DoSomeWorkAsync();
        }

        public string ExecutionReturnResult()
        {
            return DoSomeWorkAsync().Result;
        }

        public Task<string> TryCatchUsual()
        {
            try
            {
                return ThrowExceptionAsync();
            }
            catch 
            {
                Console.WriteLine("TryCatch Usual Exception caught");
                return null;
            }
        }

        public async Task<string> TryCatchAwait()
        {
            try
            {
                return await ThrowExceptionAsync();
            }
            catch
            {
                Console.WriteLine("TryCatch Await Exception caught");
                return "Query6 Exception caught";
            }
        }

        public string TryCatchReturnResult()
        {
            try
            {
                return ThrowExceptionAsync().Result;
            }
            catch
            {
                Console.WriteLine("TryCatch Return .Result Exception caught");
                return "Query5 Exception caught";
            }
        }


        private async Task<string> DoSomeWorkAsync()
        {
            return await Task.Run(() => DoSomeWork());
        }

        private string DoSomeWork()
        {
            Thread.Sleep(1000);
            // Console.WriteLine("work done");
            return "work done";
        }

        private async Task<string> ThrowExceptionAsync()
        {
            return await Task.Run(() => ThrowException());
        }

        private string ThrowException()
        {
            throw new Exception("Async Await exception example");
        }
    }
}