using CMSDatabaseConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CMSService
{
    class CMSDatabaseCrossedDeathLineHelper
    {
        public delegate void CrossedDeathLineDelegate();
        public static event CrossedDeathLineDelegate CrossedDeathLineEventHandler;

        public static void CheckCrossedDeathLine(object source, ElapsedEventArgs e)
        {            
            List<Car> cars = Connector.GetAllCars();

            if(cars.Where(x => x.CrossedDeathLine).Any())
            {
                OnCrossedDeathLine();
            }
        }

        private static void OnCrossedDeathLine()
        {
            if(CrossedDeathLineEventHandler != null)
            {
                CrossedDeathLineEventHandler.Invoke();
            }
        }
    }
}
