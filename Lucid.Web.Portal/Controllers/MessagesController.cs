using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucid.Web.Portal.Models;
using System.Diagnostics;

namespace Lucid.Web.Portal.Controllers
{   
    public class MessagesController : Controller
    {
		private readonly IMessageRepository messageRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public MessagesController() : this(new MessageRepository())
        {
        }

        public MessagesController(IMessageRepository messageRepository)
        {
			this.messageRepository = messageRepository;
        }

        //
        // GET: /Messages/

        public ViewResult Index()
        {
            return View(messageRepository.All);
        }

        //
        // GET: /Messages/Details/5

        public ViewResult Details(int id)
        {
            return View(messageRepository.Find(id));
        }

        //
        // GET: /Messages/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Messages/Create

        [HttpPost]
        public ActionResult Create(Message message)
        {
            if (ModelState.IsValid) {
                messageRepository.InsertOrUpdate(message);
                messageRepository.Save();
                NotifyRecipient(message);
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        private void NotifyRecipient(Message message)
        {
            Debug.WriteLine(message.ToString());
        }
        
        //
        // GET: /Messages/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(messageRepository.Find(id));
        }

        //
        // POST: /Messages/Edit/5

        [HttpPost]
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid) {
                messageRepository.InsertOrUpdate(message);
                messageRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Messages/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(messageRepository.Find(id));
        }

        //
        // POST: /Messages/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            messageRepository.Delete(id);
            messageRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                messageRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

