using CMSDatabaseConnector;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSMessanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task> mainAsyncDelegate = MainAsync;
            AsyncContext.Run(mainAsyncDelegate);
        }

        static async Task MainAsync()
        {
            string msg = "Mniej niż 2 tygodnie do przekroczenia terminu ważności. Czy uruchomić program CMS w celu weryfikacji?";
            bool crossedDeathLine = false;
            bool error = false;

            try
            {
                if (Connector.TryConnectToDB())
                {
                    Func<Car, bool> checkCarDelegate = CheckCar;
                    crossedDeathLine = (await GetCarsAsync()).Any(checkCarDelegate);
                }

            }
            catch (Exception ex)
            {
                error = true;
                msg = ex.Message;
            }

            if (crossedDeathLine || error)
            {                
                DialogResult input = MessageBox.Show(msg, "CMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(input == DialogResult.Yes)
                {
                    ProcessStartInfo cmsProcess = new ProcessStartInfo();
                    cmsProcess.FileName = @"C:\Users\ddyrcz\Desktop\Programowanie\C#\Projects\CMS Release\CMS v1.0\Exe\CMS\CMS.exe";

                    using (Process proc = Process.Start(cmsProcess))
                    {
                        proc.WaitForExit();
                    }                    
                }
            }
        }

        static bool CheckCar(Car car)
        {
            return car.CrossedDeathLine;
        }

        static async Task<List<Car>> GetCarsAsync()
        {
            Func<List<Car>> getCarsDelegate = GetCars;
            return await Task.Factory.StartNew(getCarsDelegate);
        }

        static List<Car> GetCars()
        {
            return Connector.GetAllCars();
        }
    }
}
