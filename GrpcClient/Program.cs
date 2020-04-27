using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace GrpcClient
{
    class Program
    {



        static async Task Main(string[] args)
        {

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var customerClient = new Customer.CustomerClient(channel);
            var input = Console.ReadLine();
            DateTime dDate;

            if (DateTime.TryParse(input, out dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
               var clientRequested = new CustomerLookupModel { UserId = input.ToString() };

                var customer = await customerClient.GetCustomerInfoAsync(clientRequested);

                Console.WriteLine($"{ customer.FirstName } { customer.LastName }");
            }
            else
            {
                Console.WriteLine("Eroare"); 
            }

            Console.ReadLine();
        }
    }
}
