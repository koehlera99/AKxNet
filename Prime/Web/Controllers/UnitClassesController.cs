using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prime.Data.Entity;

namespace Web.Controllers
{
    public class UnitClassesController : Controller
    {
        private GameContext db = new GameContext();

        // GET: UnitClasses
        public async Task<ActionResult> Index()
        {
            return View(await db.UnitClasses.ToListAsync());
        }

        // GET: UnitClasses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitClass unitClass = await db.UnitClasses.FindAsync(id);
            if (unitClass == null)
            {
                return HttpNotFound();
            }
            return View(unitClass);
        }

        // GET: UnitClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ClassId,ClassName")] UnitClass unitClass)
        {
            if (ModelState.IsValid)
            {
                db.UnitClasses.Add(unitClass);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(unitClass);
        }

        // GET: UnitClasses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitClass unitClass = await db.UnitClasses.FindAsync(id);
            if (unitClass == null)
            {
                return HttpNotFound();
            }
            return View(unitClass);
        }

        // POST: UnitClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClassId,ClassName")] UnitClass unitClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unitClass).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(unitClass);
        }

        // GET: UnitClasses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitClass unitClass = await db.UnitClasses.FindAsync(id);
            if (unitClass == null)
            {
                return HttpNotFound();
            }
            return View(unitClass);
        }

        // POST: UnitClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UnitClass unitClass = await db.UnitClasses.FindAsync(id);
            db.UnitClasses.Remove(unitClass);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
