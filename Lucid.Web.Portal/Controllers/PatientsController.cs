using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucid.Web.Portal.Models;

namespace Lucid.Web.Portal.Controllers
{   
    public class PatientsController : Controller
    {
		private readonly IPatientRepository patientRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PatientsController() : this(new PatientRepository())
        {
        }

        public PatientsController(IPatientRepository patientRepository)
        {
			this.patientRepository = patientRepository;
        }

        //
        // GET: /Patients/

        public ViewResult Index()
        {
            return View(patientRepository.All);
        }

        //
        // GET: /Patients/Details/5

        public ViewResult Details(int id)
        {
            return View(patientRepository.Find(id));
        }

        //
        // GET: /Patients/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Patients/Create

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid) {
                patientRepository.InsertOrUpdate(patient);
                patientRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Patients/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(patientRepository.Find(id));
        }

        //
        // POST: /Patients/Edit/5

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid) {
                patientRepository.InsertOrUpdate(patient);
                patientRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Patients/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(patientRepository.Find(id));
        }

        //
        // POST: /Patients/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            patientRepository.Delete(id);
            patientRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                patientRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

