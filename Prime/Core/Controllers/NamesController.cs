﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Core.Controllers
{
    public class NamesController : Controller
    {
        private readonly RpgNamesContext _context;

        public NamesController(RpgNamesContext context)
        {
            _context = context;
        }

        // GET: Names
        public async Task<IActionResult> Index()
        {
            return View(await _context.Names.OrderBy(x => x.Name).OrderBy(x => x.NameType).OrderBy(x => x.Race).ToListAsync());
        }

        // GET: Names/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var names = await _context.Names
                .FirstOrDefaultAsync(m => m.NameType == id);
            if (names == null)
            {
                return NotFound();
            }

            return View(names);
        }

        // GET: Names/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Names/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,NameType,Race,Random")] Names names)
        {
            if (ModelState.IsValid)
            {
                _context.Add(names);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(names);
        }

        // GET: Names/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var names = await _context.Names.FindAsync(id);
            if (names == null)
            {
                return NotFound();
            }
            return View(names);
        }

        // POST: Names/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,NameType,Race,Random")] Names names)
        {
            if (id != names.NameType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(names);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NamesExists(names.NameType))
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
            return View(names);
        }

        // GET: Names/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var names = await _context.Names
                .FirstOrDefaultAsync(m => m.NameType == id);
            if (names == null)
            {
                return NotFound();
            }

            return View(names);
        }

        // POST: Names/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var names = await _context.Names.FindAsync(id);
            _context.Names.Remove(names);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NamesExists(string id)
        {
            return _context.Names.Any(e => e.NameType == id);
        }
    }
}
