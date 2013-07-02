using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucid.Web.Portal.Models;

namespace Lucid.Web.Portal.Controllers
{   
    public class ChiropractorsController : Controller
    {
		private readonly IChiropractorRepository chiropractorRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ChiropractorsController() : this(new ChiropractorRepository())
        {
        }

        public ChiropractorsController(IChiropractorRepository chiropractorRepository)
        {
			this.chiropractorRepository = chiropractorRepository;
        }

        //
        // GET: /Chiropractors/

        public ViewResult Index()
        {
            return View(chiropractorRepository.All);
        }

        //
        // GET: /Chiropractors/Details/5

        public ViewResult Details(int id)
        {
            return View(chiropractorRepository.Find(id));
        }

        //
        // GET: /Chiropractors/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Chiropractors/Create

        [HttpPost]
        public ActionResult Create(Chiropractor chiropractor)
        {
            if (ModelState.IsValid) {
                chiropractorRepository.InsertOrUpdate(chiropractor);
                chiropractorRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Chiropractors/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(chiropractorRepository.Find(id));
        }

        //
        // POST: /Chiropractors/Edit/5

        [HttpPost]
        public ActionResult Edit(Chiropractor chiropractor)
        {
            if (ModelState.IsValid) {
                chiropractorRepository.InsertOrUpdate(chiropractor);
                chiropractorRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Chiropractors/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(chiropractorRepository.Find(id));
        }

        //
        // POST: /Chiropractors/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            chiropractorRepository.Delete(id);
            chiropractorRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                chiropractorRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

