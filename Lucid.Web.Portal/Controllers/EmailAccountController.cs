using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lucid.Web.Portal.Controllers
{
    public class EmailAccountController : ApiController
    {
        // GET api/emailaccount
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/emailaccount/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/emailaccount
        public void Post([FromBody]string value)
        {
        }

        // PUT api/emailaccount/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/emailaccount/5
        public void Delete(int id)
        {
        }
    }
}
