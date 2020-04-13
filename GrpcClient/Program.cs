﻿using Grpc.Core;
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
            Console.WriteLine("Introducetiun nume: ");
            var input = new HelloRequest { Name = Console.ReadLine() };

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(input);

            Console.WriteLine(reply.Message);

            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var customerClient = new Customer.(channel);

            //var clientRequested = new CustomerLookupModel { UserId = 2 };

            //var customer = await customerClient.GetCustomerInfoAsync(clientRequested);

            //Console.WriteLine($"{ customer.FirstName } { customer.LastName }");
        
            //Console.WriteLine();
            //Console.WriteLine("New Customer List");
            //Console.WriteLine();


            //using (var call = customerClient.GetNewCustomers(new NewCustomerRequest()))
            //{
            //    while (await call.ResponseStream.MoveNext())
            //    {
            //        var currentCustomer = call.ResponseStream.Current;
            //        Console.WriteLine($"{ currentCustomer.FirstName } { currentCustomer.LastName }: { currentCustomer.EmailAddress }");
            //    }
            //}
        
            Console.ReadLine();
        }
    }
}
