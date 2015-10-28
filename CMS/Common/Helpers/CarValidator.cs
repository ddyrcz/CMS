using CMSDatabaseConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Helpers
{
    static class CarValidator
    {
        /// <summary>
        /// Ckecks if car is valid
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public static bool Validate(Car car)
        {
            return
                !string.IsNullOrEmpty(car.Brand) &&
                !string.IsNullOrEmpty(car.RegistrationNumber);
        }
    }
}
