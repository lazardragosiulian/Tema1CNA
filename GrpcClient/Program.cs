using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using System;
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
            var clientRequested = new CustomerLookupModel { UserId = input.ToString() };

            var customer = await customerClient.GetCustomerInfoAsync(clientRequested);

            Console.WriteLine($"{ customer.FirstName } { customer.LastName }");

          
            Console.ReadLine();
        }
    }
}
