using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyHouse.Database;
using MyHouse.Models;

namespace MyHouse.Controllers
{
    public class MaritualStatusController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: MaritualStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.MaritualStatuses.ToListAsync());
        }

        // GET: MaritualStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritualStatus maritualStatus = await db.MaritualStatuses.FindAsync(id);
            if (maritualStatus == null)
            {
                return HttpNotFound();
            }
            return View(maritualStatus);
        }

        // GET: MaritualStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaritualStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] MaritualStatus maritualStatus)
        {
            if (ModelState.IsValid)
            {
                db.MaritualStatuses.Add(maritualStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(maritualStatus);
        }

        // GET: MaritualStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritualStatus maritualStatus = await db.MaritualStatuses.FindAsync(id);
            if (maritualStatus == null)
            {
                return HttpNotFound();
            }
            return View(maritualStatus);
        }

        // POST: MaritualStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] MaritualStatus maritualStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maritualStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(maritualStatus);
        }

        // GET: MaritualStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritualStatus maritualStatus = await db.MaritualStatuses.FindAsync(id);
            if (maritualStatus == null)
            {
                return HttpNotFound();
            }
            return View(maritualStatus);
        }

        // POST: MaritualStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MaritualStatus maritualStatus = await db.MaritualStatuses.FindAsync(id);
            db.MaritualStatuses.Remove(maritualStatus);
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
