using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using eudaci.Data;
using eudaci.Models;
using System.Linq;

namespace eudaci.API {
    [DisallowConcurrentExecution]
    public class FetchPTDataJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;

        public FetchPTDataJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = _serviceProvider.GetRequiredService<EudaciContext>();

                var date = DateTime.Now.Date;

                for (int i = 1; i <= 7; i++)
                {
                    var f_date = date.Subtract(TimeSpan.FromDays(i));
                    System.Console.WriteLine("Fetching data from " + f_date.ToString("yyyy-MM-dd"));
                    var countries = dbContext.Country.ToList();

                    foreach (var country in countries)
                    {
                        await FetchData(country, dbContext, f_date);
                    }
                }
            }
        }

        public async Task FetchData(Country country, EudaciContext eudaciContext, DateTime date) {
            var pandemic = eudaciContext.Pandemic
                .Where(p =>
                    p.Date == date
                    && p.CountryId == country.Id)
                .FirstOrDefault();
            
            if (pandemic == null) {
                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string msg = null;
                
                try
                {
                    msg = await client.GetStringAsync(
                        "https://api.covid19tracking.narrativa.com/api/country/" + country.Name +
                        "?date_from=" + date.ToString("yyyy-MM-dd") +
                        "&date_to=" + date.ToString("yyyy-MM-dd")
                    );
                }
                catch (HttpRequestException)
                {
                    return;
                }

                var json = JObject.Parse(msg);
                
                pandemic = new Pandemic{
                    Date = date,
                    Deaths = GetData(json, country, date, "today_deaths"),
                    Infected = GetData(json, country, date, "today_confirmed"),
                    Recovered = GetData(json, country, date, "today_recovered"),
                    Hospitalisations = GetData(json, country, date, "today_total_hospitalised_patients"),
                    CountryId = country.Id
                };

                eudaciContext.Add(pandemic);
                await eudaciContext.SaveChangesAsync();
            }
        }

        public int GetData(JObject json, Country country, DateTime date, string key) {
            var dates = json["dates"];
            var odate = dates[date.ToString("yyyy-MM-dd")];
            var countries = odate["countries"];
            var ocountry = countries[country.Name];
            var value = ocountry[key];

            if (value == null) {
                return -1;
            }

            return Int32.Parse(value.ToString());
        }
    }
}
