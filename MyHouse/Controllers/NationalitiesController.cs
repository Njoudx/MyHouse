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
    public class NationalitiesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Nationalities
        public async Task<ActionResult> Index()
        {
            return View(await db.Nationalities.ToListAsync());
        }

        // GET: Nationalities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nationality nationality = await db.Nationalities.FindAsync(id);
            if (nationality == null)
            {
                return HttpNotFound();
            }
            return View(nationality);
        }

        // GET: Nationalities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                db.Nationalities.Add(nationality);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nationality);
        }

        // GET: Nationalities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nationality nationality = await db.Nationalities.FindAsync(id);
            if (nationality == null)
            {
                return HttpNotFound();
            }
            return View(nationality);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nationality).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nationality);
        }

        // GET: Nationalities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nationality nationality = await db.Nationalities.FindAsync(id);
            if (nationality == null)
            {
                return HttpNotFound();
            }
            return View(nationality);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Nationality nationality = await db.Nationalities.FindAsync(id);
            db.Nationalities.Remove(nationality);
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
