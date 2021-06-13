using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eudaci.Data;
using Microsoft.AspNetCore.Authorization;
using System;
using eudaci.Models;

namespace eudaci.Controllers
{
    [AllowAnonymous]
    public class CountriesController : Controller
    {
        private readonly EudaciContext _context;

        public CountriesController(EudaciContext context)
        {
            _context = context;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Country.ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            ViewData["country"] = country;

            ViewData["pandemic"] = await _context.Pandemic
                .Where(p => p.Country.Name == country.Name)
                .OrderByDescending(p => p.Date)
                .FirstOrDefaultAsync() ?? new Pandemic{
                    Date = DateTime.Now,
                    Deaths = 0,
                    Infected = 0,
                    Recovered = 0,
                    Hospitalisations = 0
                };

            ViewData["vaccination"] = await _context.Vaccination
                .Where(p => p.Country.Name == country.Name)
                .OrderByDescending(p => p.Date)
                .FirstOrDefaultAsync() ?? new Vaccination{
                    Date = DateTime.Now,
                    QuantityFirstDose = 0,
                    QuantitySecondDose = 0
                };

            ViewData["pandemics"] = await _context.Pandemic
                .Where(p => p.Country.Name == country.Name)
                .OrderBy(p => p.Date)
                .ToListAsync();

            return View(country);
        }
    }
}
