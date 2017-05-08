using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Models;
using Garage_2_5.ViewModels;

namespace Garage_2_5.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageDataContext db = new GarageDataContext();

        // GET: ParkedVehicles
        public ActionResult Index()
        {
            var vm = new ParkedVehicleListViewModel();
            vm.ParkedVehicles = db.ParkedVehicles.Include(p => p.Member).Include(p => p.VehicleType).ToList();
            vm.SearchVehicleTypes = new SelectList(db.VehicleTypes, "Id", "Name");
            return View(vm);
        }

        [HttpPost, ActionName("Index")]
        public ActionResult Index(VehicleType SearchVehicleType, string SearchRegNum)
        {
            int SearchVehicleTypeId = 0;
            if (SearchVehicleType != null)
            {
                SearchVehicleTypeId = SearchVehicleType.Id; 
            }
            
            //Här var vi 5/5
            //VehicleType DropDownList val översätta till index lista...

            var vm = new ParkedVehicleListViewModel();
            vm.ParkedVehicles = Search(SearchVehicleTypeId, SearchRegNum);
            vm.SearchVehicleTypes = new SelectList(db.VehicleTypes, "Id", "Name");

            return View("Index", vm);
        }


        private IQueryable<ParkedVehicle> Search(int id, string regNum)
        {
            var vm = db.ParkedVehicles
                    .Where(v => id == 0 || v.VehicleType.Id == id)
                   .Where(v => regNum == null || v.RegNum.StartsWith(regNum));
            return vm; 
        }

        // GET: ParkedVehiclesDetailed
        public ActionResult DetailedList()
        {
            var parkedVehicles = db.ParkedVehicles.Include(p => p.Member).Include(p => p.VehicleType);
            return View(parkedVehicles.ToList());
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Name");
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNum,TimeOfCheckIn,VehicleTypeId,MemberId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", parkedVehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Name", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", parkedVehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Name", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNum,TimeOfCheckIn,VehicleTypeId,MemberId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", parkedVehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Name", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
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
