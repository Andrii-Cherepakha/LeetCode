using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Dropbox.Crawler
{
    public class RemoteApi
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
    }
}
