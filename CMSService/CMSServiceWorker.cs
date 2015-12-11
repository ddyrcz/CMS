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
            CMSDataService.InitService();            
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt");             
        }

        protected override void OnStop()
        {
            CMSDataService.StopService();
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt");
        }
    }
}
