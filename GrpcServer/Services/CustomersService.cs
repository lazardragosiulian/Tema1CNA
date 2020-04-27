using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        string GetHoroscop(DateTime dt)
        {
            int month = dt.Month;
            int day = dt.Day;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Varsator";
                case 2:
                    if (day <= 18)
                        return "Varsator";
                    else
                        return "Pesti";
                case 3:
                    if (day <= 20)
                        return "Pesti";
                    else
                        return "Berbec";
                case 4:
                    if (day <= 19)
                        return "Berbec";
                    else
                        return "Taur";
                case 5:
                    if (day <= 20)
                        return "Taur";
                    else
                        return "Gemeni";
                case 6:
                    if (day <= 20)
                        return "Gemeni";
                    else
                        return "Rac";
                case 7:
                    if (day <= 22)
                        return "Rac";
                    else
                        return "Leu";
                case 8:
                    if (day <= 22)
                        return "Leu";
                    else
                        return "Fecioara";
                case 9:
                    if (day <= 22)
                        return "Fecioara";
                    else
                        return "Balanta";
                case 10:
                    if (day <= 22)
                        return "Balanta";
                    else
                        return "Scorpion";
                case 11:
                    if (day <= 21)
                        return "Scorpion";
                    else
                        return "Segetator";
                case 12:
                    if (day <= 21)
                        return "Segetator";
                    else
                        return "Capricorn";
            }
            return "";
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            var data = request.UserId;
            CustomerModel output = new CustomerModel();
            Console.WriteLine("data: " + data);
            DateTime dt;
            if (DateTime.TryParse(data, out dt))
            {
                String.Format("{0:d/MM/yyyy}", dt);
                
                Console.WriteLine("zodie: " + GetHoroscop(dt));
            }
            return Task.FromResult(output);
        }

        public override async Task GetNewCustomers(
            NewCustomerRequest request, 
            IServerStreamWriter<CustomerModel> responseStream, 
            ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {   
                    FirstName = "Tim",
                    LastName = "Corey",
                    EmailAddress = "tim@iamtimcorey.com",
                    Age = 41,
                    IsAlive = true
                },
                new CustomerModel
                {
                    FirstName = "Sue",
                    LastName = "Storm",
                    EmailAddress = "sue@stormy.net",
                    Age = 28,
                    IsAlive = false
                },
                new CustomerModel
                {
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bilbo@middleearth.net",
                    Age = 117,
                    IsAlive = false
                },

            };

            foreach (var cust in customers)
            {
                await responseStream.WriteAsync(cust);
            }
        }
    }
}
