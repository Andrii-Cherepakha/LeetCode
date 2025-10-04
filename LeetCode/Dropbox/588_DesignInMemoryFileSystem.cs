namespace LeetCode.Dropbox
{
    public class DesignInMemoryFileSystem
    {
        private class Folder
        { 
            public Dictionary<string, Folder> Folders { get; private set; } // folder name, subfolders
            public Dictionary<string, string> Files{ get; private set; } // file name, file content

            public Folder()
            {
                this.Folders = new Dictionary<string, Folder>();
                this.Files = new Dictionary<string, string>();
            }
        }

        private Folder root = new Folder();

        public DesignInMemoryFileSystem()
        {

        }

        public IList<string> Ls(string path)
        {
            // If path is a file path, returns a list that only contains this file's name.
            // If path is a directory path, returns the list of file and directory names in this directory.
            // The answer should in lexicographic order.
            var result = new List<string>();

            Folder folder;

            if ("/".Equals(path))
            {
                folder = root;
                result.AddRange(folder.Folders.Keys);
                result.AddRange(folder.Files.Keys);
            }
            else
            {
                // /a
                // /a/b
                int li = path.LastIndexOf('/');
                var subPath = path.Substring(0, li);
                folder = GetFolder(subPath);
                var fileName = path.Substring(li + 1, path.Length - li - 1);

                if (folder.Files.ContainsKey(fileName))
                {
                    result.Add(fileName);
                }
                else
                {
                    // folder = folder.Folders[fileName];
                    folder = GetFolder(path);
                    result.AddRange(folder.Folders.Keys);
                    result.AddRange(folder.Files.Keys);
                }
            }

            result.Sort();

            return result;
        }

        public void Mkdir(string path)
        {
            // Makes a new directory according to the given path.
            // The given directory path does not exist.
            // If the middle directories in the path do not exist, you should create them as well.
            // path and filePath are absolute paths which begin with '/' and do not end with '/' except that the path is just "/".
            GetFolder(path);
        }

        public void AddContentToFile(string filePath, string content)
        {
            // If filePath does not exist, creates that file containing given content.
            // If filePath already exists, appends the given content to original content.
            // /a/b/c/dd  li = 6 length = 9 
            int li = filePath.LastIndexOf('/');
            var path = filePath.Substring(0, li);
            var folder = GetFolder(path);

            var fileName = filePath.Substring(li + 1, filePath.Length - li - 1);
            string existingContent = folder.Files.ContainsKey(fileName) ? folder.Files[fileName] : "";

            existingContent += content;
            folder.Files[fileName] = existingContent;
        }

        public string ReadContentFromFile(string filePath)
        {
            // Returns the content in the file at filePath.
            int li = filePath.LastIndexOf('/');
            var path = filePath.Substring(0, li);
            var folder = GetFolder(path);

            var fileName = filePath.Substring(li + 1, filePath.Length - li - 1);

            return folder.Files[fileName];
        }

        private Folder GetFolder(string path)
        {
            var subFolders = path.Split('/');
            Folder folder = root;
            for (int i = 1; i < subFolders.Length; i++)
            {
                if (!folder.Folders.ContainsKey(subFolders[i]))
                {
                    folder.Folders[subFolders[i]] = new Folder();
                }
                folder = folder.Folders[subFolders[i]];
            }
            return folder;
        }
    }
}
