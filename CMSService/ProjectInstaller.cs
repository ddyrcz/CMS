using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace CMSService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            //this.serviceProcessInstaller1.Username = "ddyrcz";
            //this.serviceProcessInstaller1.Password = "zaq1@WSX";
        }
    }
}
