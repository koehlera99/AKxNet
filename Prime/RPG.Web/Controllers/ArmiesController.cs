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
    public class ArmiesController : Controller
    {
        private readonly UnitContext _context;

        public ArmiesController(UnitContext context)
        {
            _context = context;
        }

        // GET: Armies
        public async Task<IActionResult> Index()
        {
            var unitContext = _context.Armies.Include(a => a.Player);
            return View(await unitContext.ToListAsync());
        }

        // GET: Armies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var army = await _context.Armies
                .Include(a => a.Player)
                .FirstOrDefaultAsync(m => m.ArmyId == id);
            if (army == null)
            {
                return NotFound();
            }

            return View(army);
        }

        // GET: Armies/Create
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "PlayerId");
            return View();
        }

        // POST: Armies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArmyId,ArmyName,PlayerId")] Army army)
        {
            if (ModelState.IsValid)
            {
                _context.Add(army);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "PlayerId", army.PlayerId);
            return View(army);
        }

        // GET: Armies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var army = await _context.Armies.FindAsync(id);
            if (army == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "PlayerId", army.PlayerId);
            return View(army);
        }

        // POST: Armies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArmyId,ArmyName,PlayerId")] Army army)
        {
            if (id != army.ArmyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(army);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmyExists(army.ArmyId))
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
            ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "PlayerId", army.PlayerId);
            return View(army);
        }

        // GET: Armies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var army = await _context.Armies
                .Include(a => a.Player)
                .FirstOrDefaultAsync(m => m.ArmyId == id);
            if (army == null)
            {
                return NotFound();
            }

            return View(army);
        }

        // POST: Armies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var army = await _context.Armies.FindAsync(id);
            _context.Armies.Remove(army);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmyExists(int id)
        {
            return _context.Armies.Any(e => e.ArmyId == id);
        }
    }
}
