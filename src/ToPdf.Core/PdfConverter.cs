using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ToPdf.Core
{
    /// <summary>
    /// Class. Implements IPdfConverter.
    /// </summary>
    public class PdfConverter : IPdfConverter
    {
        /// <summary>
        /// Method. Converts image to the pdf file by the path given.
        /// </summary>
        /// <param name="pathToTheImage">The path of the image source</param>
        /// <param name="pdfPath">The path to pdf output file</param>
        /// <returns></returns>
        public bool ConvertImageToPdf(string pathToTheImage, string pdfPath)
        {
            bool result = false;
            try
            {
                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                using (var stream = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    using (var imageStream = new FileStream(pathToTheImage, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image = Image.GetInstance(imageStream);

                        Image jpg = Image.GetInstance(image);
                        jpg.ScaleToFit(document.PageSize);

                        jpg.Alignment = Element.ALIGN_LEFT;
                        document.Add(jpg);
                    }
                    document.Close();
                }
                result = File.Exists(pdfPath);
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
