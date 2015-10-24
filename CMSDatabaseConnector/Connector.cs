using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSDatabaseConnector
{
    public static class Connector
    {
        /// <summary>
        /// Adds new car to CMS database
        /// </summary>
        /// <param name="newCar"></param>
        public static void AddCar(Car newCar)
        {
            if (newCar == null) return;

            try
            {
                using (CMSContext context = new CMSContext())
                {
                    int lastCarId = (
                        from car in context.Cars
                        orderby car.CarID descending
                        select car.CarID).FirstOrDefault();

                    newCar.CarID = ++lastCarId;

                    context.Cars.Add(newCar);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Removes car from CMS database
        /// </summary>
        /// <param name="carId"></param>
        public static void RemoveCar(int carId)
        {
            try
            {
                using (CMSContext context = new CMSContext())
                {
                    Car car = context.Cars.FirstOrDefault(x => x.CarID == carId);

                    context.Cars.Remove(car);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all cars from CMS database
        /// </summary>
        /// <returns></returns>
        public static List<Car> GetAllCars()
        {
            List<Car> cars = null;

            try
            {
                using (CMSContext context = new CMSContext())
                {
                    cars = context.Cars.ToList();

                    foreach (Car car in cars)
                    {
                        TrimDataSize(car);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cars;
        }

        private static void TrimDataSize(Car car)
        {            
                // trimming registration number
                if (car.RegistrationNumber != null)
                {
                    car.RegistrationNumber = car.RegistrationNumber.TrimEnd();
                }

                // trimming brand 
                if (car.Brand != null)
                {
                    car.Brand =  car.Brand.TrimEnd();
                }

                // trimming vin number
                if (car.VIN_Number != null)
                {
                    car.VIN_Number = car.VIN_Number.TrimEnd();
                }                
            
        }

        /// <summary>
        /// Gets specified car object
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public static Car GetSelectedCar(int carId)
        {
            Car car = null;

            try
            {
                using (CMSContext context = new CMSContext())
                {
                    car = context.Cars.FirstOrDefault(x => x.CarID == carId);

                    // for reducing white characters at the end
                    TrimDataSize(car);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return car;
        }

        /// <summary>
        /// Updates existing car in CMS database
        /// </summary>
        /// <param name="modifiedCar"></param>
        public static void UpdateCar(Car modifiedCar)
        {
            if (modifiedCar == null) return;

            try
            {
                using (CMSContext context = new CMSContext())
                {
                    Car oldCar = context.Cars.FirstOrDefault(x => x.CarID == modifiedCar.CarID);

                    if (oldCar != null)
                    {
                        // TODO: fond better solution
                        CopyCarObject(modifiedCar, oldCar);

                        // ---throws exception---
                        //context.Entry(oldCar).CurrentValues.SetValues(modifiedCar);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void CopyCarObject(Car modifiedCar, Car oldCar)
        {
            oldCar.Brand = modifiedCar.Brand;
            oldCar.ACPolicy = modifiedCar.ACPolicy;
            oldCar.LiftUDT = modifiedCar.LiftUDT;
            oldCar.OCPolicy = modifiedCar.OCPolicy;
            oldCar.RegistrationNumber = modifiedCar.RegistrationNumber;
            oldCar.TechLegalization = modifiedCar.TechLegalization;
            oldCar.VIN_Number = modifiedCar.VIN_Number;
            oldCar.TermTechnicalResearch = modifiedCar.TermTechnicalResearch;
        }
    }
}
