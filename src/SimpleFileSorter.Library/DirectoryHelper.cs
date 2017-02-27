using System.IO;


namespace SimpleFileSorter.Library
{

/// <summary>
///Object to manage validating and ensuring the directory is valid
/// </summary>
    public class DirectoryHelper
    {
        private string _directory;

        public DirectoryHelper(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException(directory);
            }
            _directory = Path.GetFullPath(directory);
        }
        
        public string GetFullPath()
        {
            return _directory;
        }

        public DirectoryInfo BuildSubDirectory(string subDirectory)
        {
            DirectoryInfo info =null;
            var path = CreateDirectoryPath(subDirectory);
            if (!SubDirectoryExists(subDirectory))
            {            
                info= Directory.CreateDirectory(path);
            }
            else {
                info = new DirectoryInfo(path);
            }
            return info;
        }

        private bool SubDirectoryExists(string subDirectory)
        {
            return Directory.Exists(CreateDirectoryPath(subDirectory));   
        }

        private string CreateDirectoryPath(string subPath)
        {
            return Path.Combine(_directory,subPath);
        }
    }

}
