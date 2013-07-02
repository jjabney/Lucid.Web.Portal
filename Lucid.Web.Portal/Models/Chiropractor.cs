using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lucid.Web.Portal.Models
{
    public class Chiropractor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}