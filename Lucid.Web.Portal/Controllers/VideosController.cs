using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucid.Web.Portal.Models;

namespace Lucid.Web.Portal.Controllers
{   
    public class VideosController : Controller
    {
		private readonly IVideoRepository videoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public VideosController() : this(new VideoRepository())
        {
        }

        public VideosController(IVideoRepository videoRepository)
        {
			this.videoRepository = videoRepository;
        }

        //
        // GET: /Videos/
        [Authorize(Roles="Patient,Chiropractor,Admin")]
        public ViewResult Index()
        {
            return View(videoRepository.All);
        }

        //
        // GET: /Videos/Details/5

        public ViewResult Details(int id)
        {
            return View(videoRepository.Find(id));
        }

        //
        // GET: /Videos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Videos/Create

        [HttpPost]
        public ActionResult Create(Video video)
        {
            if (ModelState.IsValid) {
                videoRepository.InsertOrUpdate(video);
                videoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Videos/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(videoRepository.Find(id));
        }

        //
        // POST: /Videos/Edit/5

        [HttpPost]
        public ActionResult Edit(Video video)
        {
            if (ModelState.IsValid) {
                videoRepository.InsertOrUpdate(video);
                videoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Videos/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(videoRepository.Find(id));
        }

        //
        // POST: /Videos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            videoRepository.Delete(id);
            videoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                videoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

