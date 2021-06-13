using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using eudaci.Data;
using eudaci.Models;
using System.Linq;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace eudaci.API {
    [DisallowConcurrentExecution]
    public class FetchDataJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;
        private HttpClient client = new HttpClient();

        public FetchDataJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = _serviceProvider.GetRequiredService<EudaciContext>();

                var date = DateTime.Now.Date;
                var countries = dbContext.Country.ToList();

                for (int i = 1; i <= 7; i++)
                {
                    var f_date = date.Subtract(TimeSpan.FromDays(i));
                    System.Console.WriteLine("Fetching data from " + f_date.ToString("yyyy-MM-dd"));

                    foreach (var country in countries)
                    {
                        await FetchData(country, dbContext, f_date);
                    }
                }

                foreach (var country in countries)
                {
                    await FetchVaccination(country, dbContext);
                }
            }
        }

        public async Task FetchVaccination(Country country, EudaciContext eudaciContext)
        {
            Stream msg = null;

            try
            {
                msg = await client.GetStreamAsync("https://raw.githubusercontent.com/owid/covid-19-data/master/public/data/vaccinations/country_data/" + country.Name + ".csv");
            }
            catch (HttpRequestException)
            {
                return;
            }

            TextReader reader = new StreamReader(msg);
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<VaccinationData>();

            foreach (var record in records)
            {
                var parsedDate = DateTime.Parse(record.date);

                int people_vaccinated = -1, people_fully_vaccinated = -1;
                int.TryParse(record.people_vaccinated, out people_vaccinated);
                int.TryParse(record.people_fully_vaccinated, out people_fully_vaccinated);

                var vaccination = eudaciContext.Vaccination
                    .Where(p =>
                        p.Date == parsedDate
                        && p.CountryId == country.Id)
                    .FirstOrDefault();

                if (vaccination == null) {
                    vaccination = new Vaccination{
                        Date = parsedDate,
                        QuantityFirstDose = people_vaccinated,
                        QuantitySecondDose = people_fully_vaccinated,
                        CountryId = country.Id
                    };

                    eudaciContext.Add(vaccination);
                    await eudaciContext.SaveChangesAsync();
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
