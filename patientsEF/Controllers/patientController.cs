using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Services;

namespace patientsEF.Controllers
{
    public class patientController : Controller
    {
        private patientsContext db = new patientsContext();
        patientsServices patientsServices = new patientsServices();
        // GET: patient
        public ActionResult Index()
        {
            return View(patientsServices.getAll());
        }

        // GET: patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patients patients = patientsServices.getOne(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // GET: patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,fname,mname,lname,gender,email,lastCheck,status,Active,creationDate,CreatedBy")] patients patients)
        {
            if (ModelState.IsValid)
            {
                bool result = patientsServices.addPatient(patients);
                if (result)
                return RedirectToAction("Index");
            }

            return View(patients);
        }

        // GET: patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patients patients = patientsServices.getOne(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,fname,mname,lname,gender,email,lastCheck,status,Active,creationDate,CreatedBy")] patients patients)
        {
            if (ModelState.IsValid)
            {
                bool result = patientsServices.updatePatient(patients);
                if (result)
                return RedirectToAction("Index");
            }
            return View(patients);
        }

        // GET: patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patients patients = patientsServices.getOne(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            patients patients = patientsServices.getOne(id);
            bool result = patientsServices.deletePatient(patients);

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
