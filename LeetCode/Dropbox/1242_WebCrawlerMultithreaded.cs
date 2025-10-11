
using System.Collections.Concurrent;

namespace LeetCode.Dropbox
{
    public class WebCrawlerMultithreaded
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
            return _result.ToList();
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
                        if(!_result.Contains(u)) _result.Add(u);
                    }
                    urlsToProcess.Add(u);
                }
            }
            StartThreads(urlsToProcess, htmlParser);
        }

        private void StartThreads(List<string> urls, HtmlParser htmlParser)
        {
            // System.Threading.Thread
            var threads = new List<System.Threading.Thread>();
            foreach (var u in urls)
            {
                var t = new Thread(() => CrawlRecursion(u, htmlParser));
                threads.Add(t);
                t.Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }
        }
    }
}
