using CMSService.ServiceReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CMSService
{
    static class CMSDataService
    {
        private static Timer _timer;  
        private static double MILISECONDS_IN_TWO_HOURS = 7200000;
                
        public static void InitService()
        {            
            CMSDatabaseCrossedDeathLineHelper.CrossedDeathLineEventHandler += CMSDatabaseCrossedDeathLineHelper_CrossedDeathLineEventHandler;

            CMSDatabaseCrossedDeathLineHelper.CheckCrossedDeathLine(null, null);

            _timer = new Timer();

            _timer.Enabled = true;
            _timer.Interval = MILISECONDS_IN_TWO_HOURS;
            _timer.Elapsed -= new ElapsedEventHandler(CMSDatabaseCrossedDeathLineHelper.CheckCrossedDeathLine);
            _timer.Elapsed += new ElapsedEventHandler(CMSDatabaseCrossedDeathLineHelper.CheckCrossedDeathLine);
        }        

        public static void StopService()
        {
            _timer = null;
        }

        private static void CMSDatabaseCrossedDeathLineHelper_CrossedDeathLineEventHandler()
        {
            // message
        }
    }
}
