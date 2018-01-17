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
    public class UnitsController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Units
        public async Task<ActionResult> Index()
        {
            var units = db.Units.Include(u => u.Campaign).Include(u => u.Squad).Include(u => u.UnitClass);
            return View(await units.ToListAsync());
        }

        // GET: Units/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            ViewBag.CampaignId = new SelectList(db.Campaigns, "CampaignId", "CampaignTitle");
            ViewBag.SquadId = new SelectList(db.Squads, "SquadId", "SquadName");
            ViewBag.ClassId = new SelectList(db.UnitClasses, "ClassId", "ClassName");
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UnitId,UnitName,CampaignId,SquadId,ClassId")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CampaignId = new SelectList(db.Campaigns, "CampaignId", "CampaignTitle", unit.CampaignId);
            ViewBag.SquadId = new SelectList(db.Squads, "SquadId", "SquadName", unit.SquadId);
            ViewBag.ClassId = new SelectList(db.UnitClasses, "ClassId", "ClassName", unit.ClassId);
            return View(unit);
        }

        // GET: Units/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampaignId = new SelectList(db.Campaigns, "CampaignId", "CampaignTitle", unit.CampaignId);
            ViewBag.SquadId = new SelectList(db.Squads, "SquadId", "SquadName", unit.SquadId);
            ViewBag.ClassId = new SelectList(db.UnitClasses, "ClassId", "ClassName", unit.ClassId);
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UnitId,UnitName,CampaignId,SquadId,ClassId")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CampaignId = new SelectList(db.Campaigns, "CampaignId", "CampaignTitle", unit.CampaignId);
            ViewBag.SquadId = new SelectList(db.Squads, "SquadId", "SquadName", unit.SquadId);
            ViewBag.ClassId = new SelectList(db.UnitClasses, "ClassId", "ClassName", unit.ClassId);
            return View(unit);
        }

        // GET: Units/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Unit unit = await db.Units.FindAsync(id);
            db.Units.Remove(unit);
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
