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
    public class MissionsController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Missions
        public async Task<ActionResult> Index()
        {
            var missions = db.Missions.Include(m => m.Campaign);
            return View(await missions.ToListAsync());
        }

        // GET: Missions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = await db.Missions.FindAsync(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // GET: Missions/Create
        public ActionResult Create()
        {
            ViewBag.CampaignId = new SelectList(db.Campaigns, "CampaignId", "CampaignTitle");
            return View();
        }

        // POST: Missions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MissionId,MissionName,MissionParameters,CampaignId")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                db.Missions.Add(mission);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CampaignId = new SelectList(db.Campaigns, "CampaignId", "CampaignTitle", mission.CampaignId);
            return View(mission);
        }

        // GET: Missions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = await db.Missions.FindAsync(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampaignId = new SelectList(db.Campaigns, "CampaignId", "CampaignTitle", mission.CampaignId);
            return View(mission);
        }

        // POST: Missions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MissionId,MissionName,MissionParameters,CampaignId")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mission).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CampaignId = new SelectList(db.Campaigns, "CampaignId", "CampaignTitle", mission.CampaignId);
            return View(mission);
        }

        // GET: Missions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = await db.Missions.FindAsync(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // POST: Missions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mission mission = await db.Missions.FindAsync(id);
            db.Missions.Remove(mission);
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
