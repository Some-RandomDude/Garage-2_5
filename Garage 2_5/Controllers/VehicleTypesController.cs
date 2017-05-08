using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage_2_5.Controllers
{
    public class VehicleTypesController : Controller
    {
        // GET: VehicleTypes
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehicleTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleTypes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
