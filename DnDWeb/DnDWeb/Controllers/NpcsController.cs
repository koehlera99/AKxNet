using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDWeb.DomainModels;
using DnDWebCore.Data;

namespace DnDWeb.Controllers
{
    public class NpcsController : Controller
    {
        private readonly DnDContext _context;

        public NpcsController(DnDContext context)
        {
            _context = context;
        }

        // GET: Npcs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Npcs.ToListAsync());
        }

        // GET: Npcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var npc = await _context.Npcs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (npc == null)
            {
                return NotFound();
            }

            return View(npc);
        }

        // GET: Npcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Npcs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Npc npc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(npc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(npc);
        }

        // GET: Npcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var npc = await _context.Npcs.SingleOrDefaultAsync(m => m.Id == id);
            if (npc == null)
            {
                return NotFound();
            }
            return View(npc);
        }

        // POST: Npcs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Npc npc)
        {
            if (id != npc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(npc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NpcExists(npc.Id))
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
            return View(npc);
        }

        // GET: Npcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var npc = await _context.Npcs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (npc == null)
            {
                return NotFound();
            }

            return View(npc);
        }

        // POST: Npcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var npc = await _context.Npcs.SingleOrDefaultAsync(m => m.Id == id);
            _context.Npcs.Remove(npc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NpcExists(int id)
        {
            return _context.Npcs.Any(e => e.Id == id);
        }
    }
}
