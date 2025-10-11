using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Dropbox
{
    public class WebCrawlerMultiTaskedAsync
    {
        public interface HtmlParser
        {
            IList<string> GetUrls(string url);
        }

        // private ConcurrentBag<string> _result = new ConcurrentBag<string>();
        private ConcurrentDictionary<string, int> _dict = new ConcurrentDictionary<string, int>();
        private string _hostname;
        private object _lock = new object();

        public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
        {
            string hostname = startUrl.Replace("http://", "");
            int pos = hostname.IndexOf('/');
            _hostname = pos == -1 ? "http://" + hostname : "http://" + hostname.Substring(0, pos);
            //_result.Add(startUrl);
            _dict.TryAdd(startUrl, 0);
            CrawlRecursion(startUrl, htmlParser).Wait();
            //CrawlRecursion(startUrl, htmlParser).GetAwaiter().GetResult();
            // CrawlRecursion2(startUrl, htmlParser).GetAwaiter().GetResult();
            // CrawlRecursion2(startUrl, htmlParser).Wait();
            //return _result.ToList();
            return _dict.Keys.ToList();
        }

        /*
        private async System.Threading.Tasks.Task CrawlRecursion2(string url, HtmlParser htmlParser)
        {
            var urls = htmlParser.GetUrls(url);

            await System.Threading.Tasks.Parallel.ForEachAsync(urls,
                new System.Threading.Tasks.ParallelOptions() { MaxDegreeOfParallelism = 10 },
                async (u, ct) => {
                    if (u.StartsWith(_hostname))
                    {
                        lock (_lock) // Time Limit Exceeded
                        {
                            if (!_result.Contains(u)) _result.Add(u);
                        }
                        await CrawlRecursion2(u, htmlParser);
                    }
                });

        }
        */

        private async System.Threading.Tasks.Task CrawlRecursion(string url, HtmlParser htmlParser)
        {
            var urls = htmlParser.GetUrls(url);
            var tasks = new List<System.Threading.Tasks.Task>();

            foreach (var u in urls)
            {
                if (u.StartsWith(_hostname))
                {
                    _dict.TryAdd(u, 0);
                    /*
                    lock (_lock) // Time Limit Exceeded
                    {
                        if (!_result.Contains(u)) _result.Add(u);
                    }
                    */
                    System.Threading.Tasks.Task t = CrawlRecursion(u, htmlParser);
                    tasks.Add(t);
                }
            }

            await System.Threading.Tasks.Task.WhenAll(tasks);
        }
    }
}
