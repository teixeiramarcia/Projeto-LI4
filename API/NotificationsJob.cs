using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Threading.Tasks;
using eudaci.Data;
using eudaci.Models;
using System.Collections.Generic;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eudaci.API {
    [DisallowConcurrentExecution]
    public class NotificationsJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;
        private SmtpClient smtpClient;
        private Random random = new Random();

        private List<String> suggestions = new List<string>{
            "Use a mask and protect yourself",
            "Be careful and follow the recommended guidelines",
            "Keep maximum attention!"
        };

        public NotificationsJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            smtpClient = new SmtpClient("localhost"){Port = 2225};
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = _serviceProvider.GetRequiredService<EudaciContext>();

                var date = DateTime.Now.Subtract(TimeSpan.FromDays(1));
                var countries = await dbContext.Country
                    .Include(c => c.users).ThenInclude(u => u.Settings)
                    .ToListAsync();

                foreach (var country in countries)
                {
                    String message;

                    message = infectedPerPop(dbContext, country);
                    if (message != "")
                    {
                        sendEmails(message, country.users);
                    }

                    message = percentInfectHospital(dbContext, country);
                    if (message != "")
                    {
                        sendEmails(message, country.users);
                    }

                    message = recoveredInfec(dbContext, country);
                    if (message != "")
                    {
                        sendEmails(message, country.users);
                    }

                    message = percentVacc(dbContext, country);
                    if (message != "")
                    {
                        sendEmails(message, country.users);
                    }
                }
            }
        }

        public void sendEmails(String message, List<ApplicationUser> users)
        {
            foreach (var user in users)
            {
                if (user.Settings.Notifications)
                {
                    SendEmail(user, message);
                }
            }
        }

        public String infectedPerPop(EudaciContext dbcontext, Country country)
        {
            var pandemic = dbcontext.Pandemic
                .Where(p => p.Country.Name == country.Name)
                .OrderByDescending(p => p.Date)
                .FirstOrDefault() ?? new Pandemic{
                    Date = DateTime.Now,
                    Deaths = 0,
                    Infected = 0,
                    Recovered = 0,
                    Hospitalisations = 0
                };

            if (pandemic.Infected == 0)
            {
                return "";
            }

            var current = pandemic.Infected - pandemic.Recovered;

            Int64 total = (Int64)current * (Int64)100000;
            double value = total / country.Population;

            if (value >= 100)
            {
                return String.Format("{0:0.00}", value) + " active cases per 100.000 inhabitants";
            }

            return "";
        } 

        public String percentInfectHospital(EudaciContext dbcontext, Country country)
        {
            var pandemic = dbcontext.Pandemic
                .Where(p => p.Country.Name == country.Name)
                .OrderByDescending(p => p.Date)
                .FirstOrDefault() ?? new Pandemic{
                    Date = DateTime.Now,
                    Deaths = 0,
                    Infected = 0,
                    Recovered = 0,
                    Hospitalisations = 0
                };

            if (pandemic.Infected == 0)
            {
                return "";
            }

            double value = (double)pandemic.Hospitalisations / (double)(pandemic.Infected - pandemic.Recovered) * 100;
            
            if (value >= 00)
            {
                return String.Format("{0:0.00}", value) + "% of the infected are hospitalized!";
            }

            return "";
        } 

        public String recoveredInfec(EudaciContext dbcontext, Country country)
        {
            var pandemic = dbcontext.Pandemic
                .Where(p => p.Country.Name == country.Name)
                .OrderByDescending(p => p.Date)
                .FirstOrDefault() ?? new Pandemic{
                    Date = DateTime.Now,
                    Deaths = 0,
                    Infected = 0,
                    Recovered = 0,
                    Hospitalisations = 0
                };

            if (pandemic.Infected == 0)
            {
                return "";
            }

            double value = (double)pandemic.Recovered / (double)(pandemic.Infected) * 100;
            
            if (value < 90)
            {
                return "Only " + String.Format("{0:0.00}", value) + "% of the infected are already recovered!";
            }

            return "";
        } 

        public String percentVacc(EudaciContext dbcontext, Country country)
        {
            var vaccination = dbcontext.Vaccination
                .Where(p => p.Country.Name == country.Name)
                .OrderByDescending(p => p.Date)
                .FirstOrDefault() ?? new Vaccination{
                    Date = DateTime.Now,
                    QuantityFirstDose = 0,
                    QuantitySecondDose = 0
                };

            if (vaccination.QuantityFirstDose == 0)
            {
                return "";
            }

            double value = (double)vaccination.QuantityFirstDose / (double)country.Population * 100;
            
            if (value >= 80)
            {
                return "Success! More than 80% of the population if now vaccinated";
            }

            return "";
        } 

        public void SendEmail(ApplicationUser user, String message)
        {
            var mailMessage = new MailMessage
                {
                    From = new MailAddress("notifications@eudaci.com"),
                    Subject = "Eudaci - Notification",
                    Body = @"
                    <html>
                        <head>
                            <style>
                                h1, h2, h3 {text-align: center; padding-top: 10px}
                            </style>
                        </head>
                        <body>
                            <h1>" + message + @"</h1>
                            <h2>" + suggestions[random.Next(suggestions.Count)] + @"</h2>
                            <h3>Eudaci - Notification</h3>
                        </body>
                    </html>
                    ",
                    IsBodyHtml = true,
                };

            mailMessage.To.Add(user.Email);

            smtpClient.Send(mailMessage);
        }
    }
}
