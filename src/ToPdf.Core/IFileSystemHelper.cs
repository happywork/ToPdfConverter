namespace ToPdf.Core
{
    public interface IFileSystemHelper
    {
        string GetNewFileNameIfExists(string fullPath);
    }
}
