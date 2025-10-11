using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LeetCode.Dropbox.Crawler
{
    public class CrawlerTest
    {
        // given a file path, it returns all files
        public IList<string> GetFiles(string filepath)
        {
            return new List<string> { "F1", "F2", "F3", "F4", "F5" };
        }

        // can scan a file
        public string ScanFile(string file)
        {
            return file + "_SCANNED ";
        }


        [Test]
        public void Client()
        {
            string filepath = "";
            var files = GetFiles(filepath);
            var result = new StringBuilder();
            foreach (var file in files)
            {
                var scanResult = ScanFile(file);
                result.Append(scanResult);
            }
            Console.WriteLine(result);
        }

        [Test]
        public void ClientThreading() // preemptive multitasking
        {
            string filepath = "";
            var files = GetFiles(filepath);

            var result = new StringBuilder();
            object _lock = new object();

            var threads = new List<Thread>();
            foreach (var file in files)
            {
                var t = new Thread(() =>
                {
                    var scanend = ScanFile(file);
                    lock (_lock)
                    {
                        result.Append(scanend);
                    }
                });
                threads.Add(t);
                t.Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            Console.WriteLine(result);
        }

        [Test]
        public void ClientParallel() // preemptive multitasking, unordered result
        {
            string filepath = "";
            var files = GetFiles(filepath);
            var result = new ConcurrentBag<string>();

            Parallel.ForEach(files,
                (file) =>
                {
                    var scanResult = ScanFile(file); // ideal when ScanFile is synchronous and thread-safe.
                    result.Add(scanResult);
                });

            Console.WriteLine(string.Join(' ', result));
        }

        private async Task<string> GetAllScanResults(string filepath = "")
        {
            var files = GetFiles(filepath);
            var tasks = new List<Task<string>>();
            foreach (var file in files)
            {
                var t = Task.Run(() => ScanFile(file));
                tasks.Add(t);
            }

            var results = await Task.WhenAll(tasks);
            return string.Join(' ', results);
        }

        [Test]
        public void ClientAsync() // cooperative multitasking
        {
            var result = GetAllScanResults().GetAwaiter().GetResult();
            Console.WriteLine(result);
        }
    }
}
