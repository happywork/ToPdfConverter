using Ninject;
using System;
using System.Windows.Forms;

namespace ToPdf.Windows.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IKernel kernel = new StandardKernel(new InjectionModule());
            var form = kernel.Get<ToPdfForm>();
            Application.Run(form);
        }
    }
}
