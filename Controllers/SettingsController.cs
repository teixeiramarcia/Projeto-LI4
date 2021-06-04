using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eudaci.Data;
using eudaci.Models;
using Microsoft.AspNetCore.Authorization;

namespace eudaci.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly EudaciContext _context;

        public SettingsController(IAuthorizationService authorizationService, EudaciContext context)
        {
            _authorizationService = authorizationService;
            _context = context;
        }

        // GET: Settings
        public async Task<IActionResult> Index()
        {
            var user = _context.ApplicationUser
                .First(r => r.Email == User.Identity.Name);

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.User == user);

            if (settings == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View("Details", settings);
        }

        // GET: Settings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Settings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Notifications,Sugestions,NotifyVaccination,NotifyPandemic")] Settings settings)
        {
            var user = _context.ApplicationUser
                .First(r => r.Email == User.Identity.Name);

            settings.User = user;

            if (ModelState.IsValid)
            {
                _context.Add(settings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(settings);
        }

        // GET: Settings/Edit/5
        public async Task<IActionResult> Edit()
        {
            var user = _context.ApplicationUser
                .First(r => r.Email == User.Identity.Name);

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.User == user);

            if (settings == null)
            {
                return NotFound();
            }
            return View(settings);
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Notifications,Sugestions,NotifyVaccination,NotifyPandemic")] Settings settings)
        {
            var user = _context.ApplicationUser
                .First(r => r.Email == User.Identity.Name);

            settings.User = user;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingsExists())
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(settings);
        }

        // GET: Settings/Delete/5
        public async Task<IActionResult> Delete()
        {
            var user = _context.ApplicationUser
                .First(r => r.Email == User.Identity.Name);

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.User == user);

            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);
        }

        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var user = _context.ApplicationUser
                .First(r => r.Email == User.Identity.Name);

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.User == user);

            _context.Settings.Remove(settings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettingsExists()
        {
            var user = _context.ApplicationUser
                .First(r => r.Email == User.Identity.Name);

            return _context.Settings.Any(m => m.User == user);
        }
    }
}
