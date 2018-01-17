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
    public class SquadsController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Squads
        public async Task<ActionResult> Index()
        {
            return View(await db.Squads.ToListAsync());
        }

        // GET: Squads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squad squad = await db.Squads.FindAsync(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        // GET: Squads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Squads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SquadId,SquadName")] Squad squad)
        {
            if (ModelState.IsValid)
            {
                db.Squads.Add(squad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(squad);
        }

        // GET: Squads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squad squad = await db.Squads.FindAsync(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        // POST: Squads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SquadId,SquadName")] Squad squad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(squad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(squad);
        }

        // GET: Squads/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squad squad = await db.Squads.FindAsync(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        // POST: Squads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Squad squad = await db.Squads.FindAsync(id);
            db.Squads.Remove(squad);
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
