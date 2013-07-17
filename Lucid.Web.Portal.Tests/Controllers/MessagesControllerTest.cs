using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucid.Web.Portal.Models;
using Lucid.Web.Portal.Controllers;

namespace Lucid.Web.Portal.Tests.Controllers
{
    [TestClass]
    public class MessagesControllerTest
    {
        [TestMethod]
        public void ChiroToPatientMessage()
        {
            var message = new Message();
            message.From = "jjabney@gmail.com";
            message.To = "jimbo@gamil.com";
            message.Content = "test";

            MessageRepository repo = new MessageRepository();
            repo.InsertOrUpdate(message);
            repo.Save();
           message = repo.AllIncluding().FirstOrDefault(x => x.From == "jjabney@gmail.com");
           Assert.IsNotNull(message);
        }
    }
}
