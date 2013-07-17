using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lucid.Web.Portal.Models;

namespace Lucid.Web.Portal.Controllers
{
    public class EmailsController : ApiController
    {
        // GET api/values
        public IEnumerable<Message> Get()
        {
            IMessageRepository repo = new MessageRepository();
            return repo.All;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
