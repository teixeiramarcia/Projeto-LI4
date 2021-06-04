using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eudaci.Data;
using Microsoft.AspNetCore.Authorization;

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
    }
}
