namespace LeetCode.Dropbox.Crawler
{
    public class Client
    {
        [NUnit.Framework.Test]
        public async Task Test1()
        {
            Console.WriteLine("Waiting for the file to be scanned...");

            var scanResult1 = await new FileScanAwaitable("F1");
            var scanResult2 = await new FileScanAwaitable("F2");
            var scanResult3 = await new FileScanAwaitable("F3");

            Console.WriteLine("File has been scanned  " + scanResult1);
            Console.WriteLine("File has been scanned  " + scanResult2);
            Console.WriteLine("File has been scanned  " + scanResult3);
        }
    }
}
