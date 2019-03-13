using Ninject.Modules;
using ToPdf.Core;

namespace ToPdf.Windows.UI
{
    public class InjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileSystemHelper>().To<FileSystemHelper>();
            Bind<IPdfConverter>().To<PdfConverter>();
        }
    }
}
