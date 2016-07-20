using CMSDatabaseConnector;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSMessanger
{
    internal class Program
    {
        #region Private Fields

        private static string _cmsPath;

        #endregion Private Fields

        #region Public Properties

        public static string CMSPath
        {
            get
            {
                if (_cmsPath == null)
                {
                    _cmsPath = ConfigurationManager.AppSettings["CMSAppPath"].ToString();
                }

                return _cmsPath;
            }
        }

        #endregion Public Properties

        #region Private Methods

        private static bool CheckCar(Car car)
        {
            return car.CrossedDeathLine;
        }

        private static List<Car> GetCars()
        {
            return Connector.GetAllCars();
        }

        private static async Task<List<Car>> GetCarsAsync()
        {
            Func<List<Car>> getCarsDelegate = GetCars;
            return await Task.Factory.StartNew(getCarsDelegate);
        }

        private static void Main(string[] args)
        {
            MainAsync();
        }

        private static async void MainAsync()
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

                if (input == DialogResult.Yes)
                {
                    ProcessStartInfo cmsProcess = new ProcessStartInfo();

                    cmsProcess.FileName = CMSPath;

                    using (Process proc = Process.Start(cmsProcess))
                    {
                        proc.WaitForExit();
                    }
                }
            }
        }

        #endregion Private Methods
    }
}