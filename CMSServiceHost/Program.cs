using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CMSServiceLib;
using System.ServiceModel.Description;

namespace CMSServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(CMSCarService)))
            {
                serviceHost.Open();
                DisplayHostInfo(serviceHost);

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press the enter key to terminate service.");
                Console.ReadLine();
            }
        }

        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine("****** Host Info ******");
            Console.WriteLine();

            foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", endpoint.Address);
                Console.WriteLine("Binding: {0}", endpoint.Binding.Name);
                Console.WriteLine("Contract: {0}", endpoint.Contract.Name);
                Console.WriteLine();
            }

            Console.WriteLine("***********************");
        }
    }
}
