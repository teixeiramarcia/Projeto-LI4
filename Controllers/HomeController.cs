using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eudaci.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using eudaci.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eudaci.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly EudaciContext _context;

        public HomeController(EudaciContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _context.Country.ToListAsync();
            ViewData["countries"] = countries;

            int infected = 0, deaths = 0, recovered = 0, hospitalisations = 0;

            foreach (var country in countries)
            {
                var pandemic = await _context.Pandemic
                    .Where(p => p.Country.Name == country.Name)
                    .OrderByDescending(p => p.Date)
                    .FirstOrDefaultAsync();

                if (pandemic != null) {
                    infected += pandemic.Infected;
                    deaths += pandemic.Deaths;
                    recovered += pandemic.Recovered;
                    hospitalisations += pandemic.Hospitalisations;
                }
            }

            ViewData["infected"] = infected;
            ViewData["deaths"] = deaths;
            ViewData["recovered"] = recovered;
            ViewData["hospitalisations"] = hospitalisations;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
