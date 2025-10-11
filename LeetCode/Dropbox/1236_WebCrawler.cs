using System.Collections.Concurrent;

namespace LeetCode.Dropbox
{
    public class WebCrawler
    {
        public interface HtmlParser
        {
            IList<string> GetUrls(string url);
        }

        public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
        {
            // the urls http://leetcode.com/problems and http://leetcode.com/contest are under the same hostname
            // Note: Consider the same URL with the trailing slash "/" as a different URL. For example, "http://news.yahoo.com", and "http://news.yahoo.com/" are different urls.
            // to crawl all links that are under the same hostname as startUrl. 
            // get host name
            string hostname = startUrl.Replace("http://", ""); // leetcode.com/problems  leetcode.com/ leetcode.com e.com/
            int pos = hostname.IndexOf('/');
            hostname = pos == -1 ? "http://" + hostname : "http://" + hostname.Substring(0, pos);
            Console.WriteLine("hostname : " + hostname + "\n");

            // Do not crawl the same link twice.
            var result = new HashSet<string>();
            var queue = new Queue<string>(); // urls
            queue.Enqueue(startUrl);
            result.Add(startUrl);
            while (queue.Count != 0)
            {
                string url = queue.Dequeue();
                var urls = htmlParser.GetUrls(url);
                foreach (var u in urls)
                {
                    Console.WriteLine(url + " -> " + u);
                    if (u.StartsWith(hostname) && !result.Contains(u)) //  
                    {
                        queue.Enqueue(u);
                        result.Add(u);
                    }
                }
            }

            return result.ToList();
        }

        private HashSet<string> _result = new HashSet<string>();
        private string _hostname;

        public IList<string> CrawlRecursion(string startUrl, HtmlParser htmlParser)
        {
            string hostname = startUrl.Replace("http://", "");
            int pos = hostname.IndexOf('/');
            _hostname = pos == -1 ? "http://" + hostname : "http://" + hostname.Substring(0, pos);
            _result.Add(startUrl);
            CrawlSubRecursion(startUrl, htmlParser);
            return _result.ToList();
        }

        private void CrawlSubRecursion(string url, HtmlParser htmlParser)
        {
            var urls = htmlParser.GetUrls(url);
            foreach (var u in urls)
            {
                if (u.StartsWith(_hostname) && !_result.Contains(u))
                {
                    _result.Add(u);
                    CrawlSubRecursion(u, htmlParser);
                }
            }
        }
    }
}
