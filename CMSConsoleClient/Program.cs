using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSDatabaseConnector;

namespace CMSConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageInput(PrintMenu());
        }

        private static int PrintMenu()
        {
            Console.WriteLine("1. Get all cars. {0}2. Add car. {1}3. Remove car.", Environment.NewLine, Environment.NewLine);
            string input = Console.ReadLine();

            int result = 0;
            int.TryParse(input, out result);
            return result;
        }

        private static void ManageInput(int input)
        {
            if (input == 0) return;

            switch (input)
            {
                case 1: PrintAllCars(); break;
                case 2: AddCar(); break;
                case 3: RemoveCar(); break;
                default: Console.WriteLine("Wrong input!"); break;
            }
        }

        private static void RemoveCar()
        {
            int carId = 0;
            Console.Write("Car id: ");
            int.TryParse(Console.ReadLine(), out carId);

            if (carId == 0)
            {
                Console.WriteLine("Wrong number format!");
                return;
            }

            try
            {
                Connector.RemoveCar(carId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static void AddCar()
        {
            foreach (Car car in _hardcodedCars)
            {
                try
                {
                    Connector.AddCar(car);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Cars has been added!");
            Console.ReadLine();
        }

        private static void PrintAllCars()
        {
            List<Car> cars = null;
            try
            {
                cars = Connector.GetAllCars();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            string carInfo = string.Empty;

            foreach (Car car in cars)
            {
                carInfo += string.Format("Id: {0},\t Brand: {1},\t Registration number{2}{3}", car.CarID, car.Brand.Trim() ?? "No data", car.RegistrationNumber ?? "No data", Environment.NewLine);
            }

            Console.WriteLine(carInfo);
            Console.ReadLine();
        }

        private static List<Car> _hardcodedCars = new List<Car>()
        {
            new Car(){
                CarID = 1,
                Brand = "Renault",
                RegistrationNumber = "SLU 38LY", 
                VIN_Number = "PO849MEMWPOEM123",
                TermTechnicalResearch = DateTime.Now, 
                TechLegalization = DateTime.Now,
                LiftUDT = DateTime.Now,
                OCPolicy = DateTime.Now,
                ACPolicy = DateTime.Now,
            },
            new Car(){
                CarID = 2,
                Brand = "Renault",
                RegistrationNumber = "SLU WY76", 
                VIN_Number = "12PFLT6673454",
                TermTechnicalResearch = DateTime.Now, 
                TechLegalization = DateTime.Now,
                LiftUDT = DateTime.Now,
                OCPolicy = DateTime.Now,
                ACPolicy = DateTime.Now,
            },
            new Car(){
                CarID = 3,
                Brand = "Renault",
                RegistrationNumber = "SLU TY77", 
                VIN_Number = "SDDWDEWD4EFDWF",
                TermTechnicalResearch = DateTime.Now, 
                TechLegalization = DateTime.Now,
                LiftUDT = DateTime.Now,
                OCPolicy = DateTime.Now,
                ACPolicy = DateTime.Now,
            },
            new Car(){
                CarID = 4,
                Brand = "Renault",
                RegistrationNumber = "SLU PO09", 
                VIN_Number = "WE343EDDMFRPQ",
                TermTechnicalResearch = DateTime.Now, 
                TechLegalization = DateTime.Now,
                LiftUDT = DateTime.Now,
                OCPolicy = DateTime.Now,
                ACPolicy = DateTime.Now,
            },
            new Car(){
                CarID = 5,
                Brand = "Renault",
                RegistrationNumber = "SLU V6GZ", 
                VIN_Number = "RRMGGTJT445334GG",
                TermTechnicalResearch = DateTime.Now, 
                TechLegalization = DateTime.Now,
                LiftUDT = DateTime.Now,
                OCPolicy = DateTime.Now,
                ACPolicy = DateTime.Now,
            },
        };
    }
}
