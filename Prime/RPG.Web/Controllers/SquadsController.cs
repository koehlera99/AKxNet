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
    public class SquadsController : Controller
    {
        private readonly UnitContext _context;

        public SquadsController(UnitContext context)
        {
            _context = context;
        }

        // GET: Squads
        public async Task<IActionResult> Index()
        {
            var unitContext = _context.Squads.Include(s => s.Platoon);
            return View(await unitContext.ToListAsync());
        }

        // GET: Squads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squad = await _context.Squads
                .Include(s => s.Platoon)
                .FirstOrDefaultAsync(m => m.SquadId == id);
            if (squad == null)
            {
                return NotFound();
            }

            return View(squad);
        }

        // GET: Squads/Create
        public IActionResult Create()
        {
            ViewData["PlatoonId"] = new SelectList(_context.Platoons, "PlatoonId", "PlatoonId");
            return View();
        }

        // POST: Squads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SquadId,SquadName,PlatoonId")] Squad squad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(squad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlatoonId"] = new SelectList(_context.Platoons, "PlatoonId", "PlatoonId", squad.PlatoonId);
            return View(squad);
        }

        // GET: Squads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squad = await _context.Squads.FindAsync(id);
            if (squad == null)
            {
                return NotFound();
            }
            ViewData["PlatoonId"] = new SelectList(_context.Platoons, "PlatoonId", "PlatoonId", squad.PlatoonId);
            return View(squad);
        }

        // POST: Squads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SquadId,SquadName,PlatoonId")] Squad squad)
        {
            if (id != squad.SquadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(squad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SquadExists(squad.SquadId))
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
            ViewData["PlatoonId"] = new SelectList(_context.Platoons, "PlatoonId", "PlatoonId", squad.PlatoonId);
            return View(squad);
        }

        // GET: Squads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squad = await _context.Squads
                .Include(s => s.Platoon)
                .FirstOrDefaultAsync(m => m.SquadId == id);
            if (squad == null)
            {
                return NotFound();
            }

            return View(squad);
        }

        // POST: Squads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var squad = await _context.Squads.FindAsync(id);
            _context.Squads.Remove(squad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SquadExists(int id)
        {
            return _context.Squads.Any(e => e.SquadId == id);
        }
    }
}
