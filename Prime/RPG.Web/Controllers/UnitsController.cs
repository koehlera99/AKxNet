﻿using System;
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
    public class UnitsController : Controller
    {
        private readonly UnitContext _context;

        public UnitsController(UnitContext context)
        {
            _context = context;
        }

        // GET: Units
        public async Task<IActionResult> Index()
        {
            var unitContext = _context.Units.Include(u => u.Squad);
            return View(await unitContext.ToListAsync());
        }

        // GET: Units/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units
                .Include(u => u.Squad)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: Units/Create
        public IActionResult Create()
        {
            ViewData["SquadId"] = new SelectList(_context.Squads, "SquadId", "SquadId");
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitId,UnitName,SquadId,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,Stamina,Endurance,Accuracy,Reflex,Vitality,Fortitude,Knowledge,Perception,Faith,Will,Spirit,Luck,CritChance,CritBonus,AttackSpeed,MoveSpeed,Cloth,Leather,Chain,Ring,Scale,Plate,Shields,SlashingWeapons,BluntWeapons,PiercingWeapons")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SquadId"] = new SelectList(_context.Squads, "SquadId", "SquadId", unit.SquadId);
            return View(unit);
        }

        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            ViewData["SquadId"] = new SelectList(_context.Squads, "SquadId", "SquadId", unit.SquadId);
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitId,UnitName,SquadId,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,Stamina,Endurance,Accuracy,Reflex,Vitality,Fortitude,Knowledge,Perception,Faith,Will,Spirit,Luck,CritChance,CritBonus,AttackSpeed,MoveSpeed,Cloth,Leather,Chain,Ring,Scale,Plate,Shields,SlashingWeapons,BluntWeapons,PiercingWeapons")] Unit unit)
        {
            if (id != unit.UnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitExists(unit.UnitId))
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
            ViewData["SquadId"] = new SelectList(_context.Squads, "SquadId", "SquadId", unit.SquadId);
            return View(unit);
        }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units
                .Include(u => u.Squad)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return _context.Units.Any(e => e.UnitId == id);
        }
    }
}
