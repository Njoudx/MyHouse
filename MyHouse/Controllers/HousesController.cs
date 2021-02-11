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
    public class HousesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Houses
        public async Task<ActionResult> Index()
        {
            var houses = db.Houses.Include(h => h.Employee).Include(h => h.HouseType);
            return View(await houses.ToListAsync());
        }

        // GET: Houses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = await db.Houses.FindAsync(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName");
            ViewBag.HouseTypeId = new SelectList(db.HouseTypes, "Id", "Id");
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Number,HouseTypeId,Bedrooms,IsFurnished,LogId,WarrantyStart,WarrantyEnd,RentPrice,ContractNumber,Owner,OwnershipRegisteration,Location,EmployeeId")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", house.EmployeeId);
            ViewBag.HouseTypeId = new SelectList(db.HouseTypes, "Id", "Id", house.HouseTypeId);
            return View(house);
        }

        // GET: Houses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = await db.Houses.FindAsync(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", house.EmployeeId);
            ViewBag.HouseTypeId = new SelectList(db.HouseTypes, "Id", "Id", house.HouseTypeId);
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Number,HouseTypeId,Bedrooms,IsFurnished,LogId,WarrantyStart,WarrantyEnd,RentPrice,ContractNumber,Owner,OwnershipRegisteration,Location,EmployeeId")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", house.EmployeeId);
            ViewBag.HouseTypeId = new SelectList(db.HouseTypes, "Id", "Id", house.HouseTypeId);
            return View(house);
        }

        // GET: Houses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = await db.Houses.FindAsync(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            House house = await db.Houses.FindAsync(id);
            db.Houses.Remove(house);
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
