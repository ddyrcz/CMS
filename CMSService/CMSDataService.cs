using CMSService.ServiceReference;
using System;
using System.Timers;

namespace CMSService
{
    static class CMSDataService
    {
        private static Timer _timer;
        private static double MILISECONDS_IN_TWO_HOURS = 7200000;
        private static int MILISECONDS_IN_THREE_MINUTES = 180000;    

        public static void InitService()
        {
            FirstRunDelay();    

            CMSDatabaseCrossedDeathLineHelper.CrossedDeathLineEventHandler += CMSDatabaseCrossedDeathLineHelper_CrossedDeathLineEventHandler;
            CMSDatabaseCrossedDeathLineHelper.CheckCrossedDeathLine(null, null);

            _timer = new Timer(MILISECONDS_IN_TWO_HOURS);

            _timer.Enabled = true;
            _timer.Elapsed -= new ElapsedEventHandler(CMSDatabaseCrossedDeathLineHelper.CheckCrossedDeathLine);
            _timer.Elapsed += new ElapsedEventHandler(CMSDatabaseCrossedDeathLineHelper.CheckCrossedDeathLine);
        }

        public static void StopService()
        {
            _timer = null;
        }

        private static void CMSDatabaseCrossedDeathLineHelper_CrossedDeathLineEventHandler()
        {
            using (MessageMessengerClient service = new MessageMessengerClient())
            {
                service.ShowMessageOnServerSide("Mniej niż 2 tygodnia do przekroczenia terminu ważności!", "CMS");
            }
        }

        private static void FirstRunDelay()
        {
            System.Threading.Thread.Sleep(MILISECONDS_IN_THREE_MINUTES);
        }
    }
}
