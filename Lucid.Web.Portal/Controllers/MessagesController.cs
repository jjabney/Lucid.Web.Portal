using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucid.Web.Portal.Models;
using System.Diagnostics;
using System.Net.Mail;
using SendGrid;
using System.Net.Mime;
using System.Web.Security;
using Lucid.Common;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Lucid.Web.Portal.Controllers
{
     [Authorize]
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
        [Authorize(Roles="Chiropractor,Patient")]
        public ViewResult Index()
        {
           MembershipUser ms = Membership.GetUser(User.Identity.Name);
           return View(messageRepository.All.Where(x => x.To == ms.Email));
        }

        //
        // GET: /Messages/Details/5
        [Authorize(Roles = "Chiropractor,Patient")]
        public ViewResult Details(int id)
        {
            var message = messageRepository.Find(id);
            if (message != null)
            {
                message.IsRead = true;
                messageRepository.InsertOrUpdate(message);
                messageRepository.Save();
            }
            return View(message);
        }

        //
        // GET: /Messages/Create
        [Authorize(Roles = "Chiropractor,Patient")]
        public ActionResult Create()
        {
            Message message = new Message();
            message.From = Membership.GetUser().Email;
          
            return View(message);
        } 

        //
        // POST: /Messages/Create

        [HttpPost]
        [Authorize(Roles = "Chiropractor,Patient")]
        public ActionResult Create(Message message)
        {
         
            if (ModelState.IsValid) {
                messageRepository.InsertOrUpdate(message);
                messageRepository.Save();
    

                SendEmail(message);

                return RedirectToAction("Index");
            } else {
				return View(message);
			}
        }

        private void SendEmail(Message message)
        {
            string subject = "";
            string textContent = "";
            string htmlContent = "";
            string link = "";
            string userName = Membership.GetUserNameByEmail(message.To);
            if (String.IsNullOrEmpty(userName))
            {
                link = string.Format("{0}account/activate?u={1}&r={2}", GetBaseUrl(), Security.DES_encrypt(message.To), Security.DES_encrypt("Patient"));
                subject = "An important message from your chiropractor";
                textContent = "Your chiropractor has sent you an important message.  \n\n Please click on the following link to view the message \n\n" + link;
                htmlContent = "<p>Your chiropractor has sent you an important message.</p><p><a href='" + link + "'>Please click here to view the message</a>";

            }
            else
            {
                link = string.Format("{0}{1}", GetBaseUrl(), "messages");
                string[] roles = Roles.GetRolesForUser(userName);
                if (roles.Length > 0 && roles[0].Equals("Patient"))
                {
                    subject = "An important message from your chiropractor";
                    textContent = "Your chiropractor has sent you an important message.  \n\n Please click on the following link to view the message \n\n" + link;
                    htmlContent ="<p>Your chiropractor has sent you an important message.</p><p><a href='" + link + "'>Please click here to view the message</a>";

                }
                else
                {
                    subject = "An important message from your patient";
                    textContent = "Your patient has sent you an important message.  \n\n Please click on the following link to view the message \n\n" + link;
                    htmlContent ="<p>Your patient has sent you an important message.</p><p><a href='" + link + "'>Please click here to view the message</a>";

                }
            }
            MailMessage mailMsg = new MailMessage();
            // To
            mailMsg.To.Add(new MailAddress(message.To));
            // From
            mailMsg.From = new MailAddress("donotreply@lucidclinicalsolutions.com");
            // Subject and multipart/alternative Body
            mailMsg.Subject = subject;
           
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(textContent, null, MediaTypeNames.Text.Plain));
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(htmlContent, null, MediaTypeNames.Text.Html));
            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMsg);
        }

        
        //
        // GET: /Messages/Edit/5
        [Authorize(Roles = "Chiropractor,Patient")]
        public ActionResult Reply(int id)
        {
             Message message = messageRepository.Find(id);
             return View(message);
        }

        //
        // POST: /Messages/Edit/5

        [HttpPost]
        [Authorize(Roles = "Chiropractor,Patient")]
        public ActionResult Reply(Message message)
        {
            if (ModelState.IsValid) 
            {

                Message replyMessage = new Message();
                replyMessage.To = message.From;
                replyMessage.From = message.To;
                replyMessage.Content = message.Content;

                messageRepository.InsertOrUpdate(replyMessage);
                messageRepository.Save();
                SendEmail(replyMessage);
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Messages/Delete/5
        [Authorize(Roles = "Chiropractor,Patient")]
        public ActionResult Delete(int id)
        {
            return View(messageRepository.Find(id));
        }

        //
        // POST: /Messages/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Chiropractor,Patient")]
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

         public string GetBaseUrl()
        {
    var request = HttpContext.Request;
    var appUrl = HttpRuntime.AppDomainAppVirtualPath;
    var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

    return baseUrl;
    }


    }
}

