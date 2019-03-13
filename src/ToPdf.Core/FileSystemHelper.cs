using System.IO;

namespace ToPdf.Core
{
    /// <summary>
    /// Class. Helps to interact with the file system.
    /// </summary>
    public class FileSystemHelper : IFileSystemHelper
    {
        /// <summary>
        /// Method. Adds the (n) to the filename if the file with the same name already exists.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public string GetNewFileNameIfExists(string fullPath)
        {
            int count = 1;

            string fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
            string extension = Path.GetExtension(fullPath);
            string path = Path.GetDirectoryName(fullPath);
            string newFullPath = fullPath;

            while (File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                newFullPath = Path.Combine(path, tempFileName + extension);
            }
            return newFullPath;
        }
    }
}
