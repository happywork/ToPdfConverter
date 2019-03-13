using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ToPdf.Core;

namespace ToPdf.Windows.UI
{
    /// <summary>
    /// The main form. Converts the image to the pdf.
    /// </summary>
    public partial class ToPdfForm : Form
    {
        /// <summary>
        /// Constructor. Initializes the component
        /// </summary>
        public ToPdfForm(IPdfConverter pdfConverter, IFileSystemHelper fileSystemHelper)
        {
            _pdfConverter = pdfConverter;
            _fileSystemHelper = fileSystemHelper;
            InitializeComponent();
        }

        /// <summary>
        /// Methd. Handles the from load event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertToPdfLoad(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                var imagePath = string.Join(" ", args.Skip(1).ToArray());
                string pdfPath = GetThePdfPath(imagePath);

                bool result = _pdfConverter.ConvertImageToPdf(imagePath, pdfPath);
            }

            Application.Exit();
        }

        /// <summary>
        /// Gets the pdf path based on the image path
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        private string GetThePdfPath(string imagePath)
        {
            var ext = Path.GetExtension(imagePath);
            var pdfPath = imagePath.Replace(ext, ".pdf");
            pdfPath = _fileSystemHelper.GetNewFileNameIfExists(pdfPath);
            return pdfPath;
        }

        private readonly IFileSystemHelper _fileSystemHelper;
        private readonly IPdfConverter _pdfConverter;
    }
}
