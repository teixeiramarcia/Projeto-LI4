using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eudaci.Data;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vaccination
                .Include(r => r.Country)
                .ToListAsync()
            );
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
