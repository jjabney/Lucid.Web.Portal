using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucid.Web.Portal.Models;
using System.Web.Security;

namespace Lucid.Web.Portal.Controllers
{   
    public class TreatmentPlanController : Controller
    {
		private readonly ITreatmentPlanRepository treatmentplanRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TreatmentPlanController() : this(new TreatmentPlanRepository())
        {
        }

        public TreatmentPlanController(ITreatmentPlanRepository treatmentplanRepository)
        {
			this.treatmentplanRepository = treatmentplanRepository;
        }

        //
        // GET: /TreatmentPlan/

        public ViewResult Index()
        {
            return View(treatmentplanRepository.All);
        }

        //
        // GET: /TreatmentPlan/Details/5

        public ViewResult Details(int id)
        {
            return View(treatmentplanRepository.Find(id));
        }

        //
        // GET: /TreatmentPlan/Create

        public ActionResult Create()
        {
            TreatmentPlan tp = new TreatmentPlan();
            tp.Treatments = new List<Treatment>();
            IVideoRepository videoRepository = new VideoRepository();
            foreach (var v in videoRepository.All)
            {
                var t = new Treatment();
                t.Title = v.Title;
                t.Url = v.MobileUrl;

                tp.Treatments.Add(t);
            }

            tp.SelectedTreatmentIds = new List<int>();

            return View(tp);
        }

     

        //
        // POST: /TreatmentPlan/Create

        [HttpPost]
        public ActionResult Create(FormCollection treatmentplan)
        {
            var to = treatmentplan["EmailAddress"];
            var from = Membership.GetUser().Email;
            if (treatmentplan["SelectedTreatmentIds"] != null)
            {
                var videos = treatmentplan["SelectedTreatmentIds"].Split(',');
            }

            //if (ModelState.IsValid) {
            //    treatmentplanRepository.InsertOrUpdate(treatmentplan);
            //    treatmentplanRepository.Save();


                return RedirectToAction("Index");


            //} else {
            //    return View();
            //}
        }
        
        //
        // GET: /TreatmentPlan/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(treatmentplanRepository.Find(id));
        }

        //
        // POST: /TreatmentPlan/Edit/5

        [HttpPost]
        public ActionResult Edit(TreatmentPlan treatmentplan)
        {
            if (ModelState.IsValid) {
                treatmentplanRepository.InsertOrUpdate(treatmentplan);
                treatmentplanRepository.Save();
                return RedirectToAction("Edit",treatmentplan.Id);
            } else {
				return View();
			}
        }

        //
        // GET: /TreatmentPlan/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(treatmentplanRepository.Find(id));
        }

        //
        // POST: /TreatmentPlan/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            treatmentplanRepository.Delete(id);
            treatmentplanRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                treatmentplanRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

