using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lucid.Web.Portal.Models
{
    public class MessageToken
    {
        [Key]
        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}