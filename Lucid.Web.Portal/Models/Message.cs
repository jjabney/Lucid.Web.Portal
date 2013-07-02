using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace Lucid.Web.Portal.Models
{
    public class Message
    {
        public Message()
        {
            Created = DateTime.Now.ToUniversalTime();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

      
        public DateTime Created { get; private set; }

        public bool IsRead { get; private set; }


        public override string ToString()
        {
            return Json.Encode(this);
        }
    }
}