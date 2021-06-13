using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eudaci.Data;
using Microsoft.AspNetCore.Authorization;
using System;

namespace eudaci.Controllers
{
    [AllowAnonymous]
    public class VaccinationsController : Controller
    {
        private readonly EudaciContext _context;

        public VaccinationsController(EudaciContext context)
        {
            _context = context;
        }

        // GET: Vaccinations
        public async Task<IActionResult> Index(DateTime date, String country = "")
        {
            if (country == null)
            {
                country = "";
            }

            ViewData["country"] = country;
            ViewData["countries"] = await _context.Country.ToListAsync();

            if (date.Year >= 2000)
            {
                ViewData["all"] = false;
                ViewData["date"] = date;

                ViewData["vaccinations"] = await _context.Vaccination
                .Include(r => r.Country)
                .Where(p =>
                    p.Date == date &&
                    (country == "" || p.Country.Name.Contains(country))
                )
                .OrderByDescending(p => p.Date)
                .ToListAsync();

                return View();
            }

            ViewData["all"] = true;

            ViewData["vaccinations"] = await _context.Vaccination
                .Include(r => r.Country)
                .Where(p => country == "" || p.Country.Name.Contains(country))
                .OrderByDescending(p => p.Date)
                .ToListAsync();

            return View();
        }

        // GET: Vaccinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccination = await _context.Vaccination
                .Include(r => r.Country)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (vaccination == null)
            {
                return NotFound();
            }

            return View(vaccination);
        }

        private bool VaccinationExists(int id)
        {
            return _context.Vaccination.Any(e => e.Id == id);
        }
    }
}
