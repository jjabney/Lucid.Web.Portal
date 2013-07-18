using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lucid.Web.Portal.Models;

namespace Lucid.Web.Portal.Controllers
{
    public class AccountsController : Controller
    {

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            IUserRepository userRepository = new UserRepository();
            user.Email = "jjabney@gmail.com";
            user.RegistrationDate = DateTime.UtcNow;
            user.Password = Lucid.Common.PasswordHash.CreateHash(user.Password);
            userRepository.InsertOrUpdate(user);
            userRepository.Save();
            return View();
        }
    }
}
