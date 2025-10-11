using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Dropbox
{
    public class WebCrawlerMultiTasked
    {
        public interface HtmlParser
        {
            IList<string> GetUrls(string url);
        }

        private ConcurrentBag<string> _result = new ConcurrentBag<string>();
        private string _hostname;
        private object _lock = new object();

        public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
        {
            string hostname = startUrl.Replace("http://", "");
            int pos = hostname.IndexOf('/');
            _hostname = pos == -1 ? "http://" + hostname : "http://" + hostname.Substring(0, pos);
            _result.Add(startUrl);
            CrawlRecursion(startUrl, htmlParser);
            return _result.Distinct().ToList(); // hack
        }

        private void CrawlRecursion(string url, HtmlParser htmlParser)
        {
            var urls = htmlParser.GetUrls(url);
            List<string> urlsToProcess = new List<string>();
            foreach (var u in urls)
            {
                if (u.StartsWith(_hostname))
                {
                    lock (_lock) // Time Limit Exceeded
                    {
                        if (!_result.Contains(u)) _result.Add(u);
                    }
                    urlsToProcess.Add(u);
                }
            }
            StartTasks(urlsToProcess, htmlParser);
        }

        private void StartTasks(List<string> urls, HtmlParser htmlParser)
        {
            var tasks = new List<System.Threading.Tasks.Task>();

            foreach (var u in urls)
            {
                var t = System.Threading.Tasks.Task.Run(() => CrawlRecursion(u, htmlParser));
                tasks.Add(t);
            }

            System.Threading.Tasks.Task.WaitAll(tasks);
        }
    }
}
