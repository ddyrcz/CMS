using CMS.ViewModels;
using System.Windows;

namespace CMS
{
    public class AppBootstrapper : Caliburn.Micro.BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<CarsViewModel>();
        }
    }
}
