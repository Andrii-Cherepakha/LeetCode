using System.Runtime.CompilerServices;


namespace LeetCode.Dropbox.Crawler
{
    public class FileScanAwaiter : INotifyCompletion
    {
        private volatile  Action _continuation;
        private volatile  string _result;
        private volatile  bool _completed;

        public FileScanAwaiter(string filePath)
        {
            _completed = false;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                var rnd = new Random();
                int n = rnd.Next(500);
                Thread.Sleep(n); // simulate async delay
                _result = n + "_" + new RemoteApi().ScanFile(filePath);
                _completed = true;
                if (_continuation != null)
                {
                    // Invoke the continuation to resume awaiting code
                    _continuation();
                    _continuation = null;
                }
            }); 

        }

        public void OnCompleted(Action continuation)
        {
            if (IsCompleted)
            {
                continuation();
                _continuation = null;
            }
            else
            {
                _continuation = continuation;
            }
        }

        public bool IsCompleted => _completed;

        public string GetResult() => _result;
    }
}
