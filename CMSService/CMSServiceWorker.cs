using System;
using System.ServiceModel;
using System.ServiceProcess;

namespace CMSService
{
    public partial class CMSServiceWorker : ServiceBase
    {
        public CMSServiceWorker()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt");            
            CMSDataService.InitService();
        }

        protected override void OnStop()
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt");
            CMSDataService.StopService();            
        }
    }
}
