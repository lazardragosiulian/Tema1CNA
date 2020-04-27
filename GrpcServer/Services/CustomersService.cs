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

        

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            var data = request.UserId;
            CustomerModel output = new CustomerModel();
            Console.WriteLine("data: " + data);
            DateTime dt;
            if (DateTime.TryParse(data, out dt))
            {
                String.Format("{0:d/MM/yyyy}", dt);
                string GetHoroName(DateTime dt)
                {
                    int month = dt.Month;
                    int day = dt.Day;
                    switch (month)
                    {
                        case 1:
                            if (day <= 19)
                                return "Capricorn";
                            else
                                return "Aquarius";

                        case 2:
                            if (day <= 18)
                                return "Aquarius";
                            else
                                return "Pisces";
                        case 3:
                            if (day <= 20)
                                return "Pisces";
                            else
                                return "Aries";
                        case 4:
                            if (day <= 19)
                                return "Aries";
                            else
                                return "Taurus";
                        case 5:
                            if (day <= 20)
                                return "Taurus";
                            else
                                return "Gemini";
                        case 6:
                            if (day <= 20)
                                return "Gemini";
                            else
                                return "Cancer";
                        case 7:
                            if (day <= 22)
                                return "Cancer";
                            else
                                return "Leo";
                        case 8:
                            if (day <= 22)
                                return "Leo";
                            else
                                return "Virgo";
                        case 9:
                            if (day <= 22)
                                return "Virgo";
                            else
                                return "Libra";
                        case 10:
                            if (day <= 22)
                                return "Libra";
                            else
                                return "Scorpio";
                        case 11:
                            if (day <= 21)
                                return "Scorpio";
                            else
                                return "Sagittarius";
                        case 12:
                            if (day <= 21)
                                return "Sagittarius";
                            else
                                return "Capricorn";
                    }
                    return "";
                }
                Console.WriteLine("zodie: " + GetHoroName(dt));
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
