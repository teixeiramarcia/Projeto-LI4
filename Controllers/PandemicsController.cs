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
    public class PandemicsController : Controller
    {
        private readonly EudaciContext _context;

        public PandemicsController(EudaciContext context)
        {
            _context = context;
        }

        // GET: Pandemics
        public async Task<IActionResult> Index(DateTime date, String country = "")
        {
            if (country == null) {
                country = "";
            }

            ViewData["country"] = country;
            ViewData["countries"] = await _context.Country.ToListAsync();

            if (date.Year >= 2000)
            {
                ViewData["all"] = false;
                ViewData["date"] = date;

                ViewData["pandemics"] = await _context.Pandemic
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

            ViewData["pandemics"] = await _context.Pandemic
                .Include(r => r.Country)
                .Where(p => country == "" || p.Country.Name.Contains(country))
                .OrderByDescending(p => p.Date)
                .ToListAsync();

            return View();
        }

        // GET: Pandemics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pandemic = await _context.Pandemic
                .Include(r => r.Country)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pandemic == null)
            {
                return NotFound();
            }

            return View(pandemic);
        }

        private bool PandemicExists(int id)
        {
            return _context.Pandemic.Any(e => e.Id == id);
        }
    }
}
