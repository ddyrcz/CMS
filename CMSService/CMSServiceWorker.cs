using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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
