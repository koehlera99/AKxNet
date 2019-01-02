using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPG.Web.Data;
using RPG.Web.Models.Unit;

namespace RPG.Web.Controllers
{
    public class PlatoonsController : Controller
    {
        private readonly UnitContext _context;

        public PlatoonsController(UnitContext context)
        {
            _context = context;
        }

        // GET: Platoons
        public async Task<IActionResult> Index()
        {
            var unitContext = _context.Platoons.Include(p => p.Army);
            return View(await unitContext.ToListAsync());
        }

        // GET: Platoons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platoon = await _context.Platoons
                .Include(p => p.Army)
                .FirstOrDefaultAsync(m => m.PlatoonId == id);
            if (platoon == null)
            {
                return NotFound();
            }

            return View(platoon);
        }

        // GET: Platoons/Create
        public IActionResult Create()
        {
            ViewData["ArmyId"] = new SelectList(_context.Armies, "ArmyId", "ArmyId");
            return View();
        }

        // POST: Platoons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlatoonId,PlatoonName,ArmyId")] Platoon platoon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platoon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArmyId"] = new SelectList(_context.Armies, "ArmyId", "ArmyId", platoon.ArmyId);
            return View(platoon);
        }

        // GET: Platoons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platoon = await _context.Platoons.FindAsync(id);
            if (platoon == null)
            {
                return NotFound();
            }
            ViewData["ArmyId"] = new SelectList(_context.Armies, "ArmyId", "ArmyId", platoon.ArmyId);
            return View(platoon);
        }

        // POST: Platoons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlatoonId,PlatoonName,ArmyId")] Platoon platoon)
        {
            if (id != platoon.PlatoonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platoon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoonExists(platoon.PlatoonId))
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
            ViewData["ArmyId"] = new SelectList(_context.Armies, "ArmyId", "ArmyId", platoon.ArmyId);
            return View(platoon);
        }

        // GET: Platoons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platoon = await _context.Platoons
                .Include(p => p.Army)
                .FirstOrDefaultAsync(m => m.PlatoonId == id);
            if (platoon == null)
            {
                return NotFound();
            }

            return View(platoon);
        }

        // POST: Platoons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platoon = await _context.Platoons.FindAsync(id);
            _context.Platoons.Remove(platoon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatoonExists(int id)
        {
            return _context.Platoons.Any(e => e.PlatoonId == id);
        }
    }
}
