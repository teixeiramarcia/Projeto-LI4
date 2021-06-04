using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eudaci.Data;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pandemic
                .Include(r => r.Country)
                .ToListAsync()
            );
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
