namespace ToPdf.Core
{
    /// <summary>
    /// Interface. Describes the pdf converter.
    /// </summary>
    public interface IPdfConverter
    {
        /// <summary>
        /// Converts image to the pdf file by the path given.
        /// </summary>
        /// <param name="pathToTheImage">The path of the image source</param>
        /// <param name="pdfPath">The path to pdf output file</param>
        /// <returns>True if successfully</returns>
        bool ConvertImageToPdf(string pathToTheImage, string pdfPath);
    }
}
