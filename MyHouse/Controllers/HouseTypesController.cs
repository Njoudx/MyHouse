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
    public class HouseTypesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: HouseTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.HouseTypes.ToListAsync());
        }

        // GET: HouseTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseType houseType = await db.HouseTypes.FindAsync(id);
            if (houseType == null)
            {
                return HttpNotFound();
            }
            return View(houseType);
        }

        // GET: HouseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] HouseType houseType)
        {
            if (ModelState.IsValid)
            {
                db.HouseTypes.Add(houseType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(houseType);
        }

        // GET: HouseTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseType houseType = await db.HouseTypes.FindAsync(id);
            if (houseType == null)
            {
                return HttpNotFound();
            }
            return View(houseType);
        }

        // POST: HouseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] HouseType houseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(houseType);
        }

        // GET: HouseTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseType houseType = await db.HouseTypes.FindAsync(id);
            if (houseType == null)
            {
                return HttpNotFound();
            }
            return View(houseType);
        }

        // POST: HouseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HouseType houseType = await db.HouseTypes.FindAsync(id);
            db.HouseTypes.Remove(houseType);
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
