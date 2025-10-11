
namespace LeetCode.Dropbox.Crawler
{
    public class FileScanAwaitable
    {
        private readonly string _filePath;

        public FileScanAwaitable(string filePath)
        {
            _filePath = filePath;
        }

        public FileScanAwaiter GetAwaiter()
        {
            return new FileScanAwaiter(_filePath);
        }
    }
}
