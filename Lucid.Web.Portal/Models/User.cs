using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lucid.Web.Portal.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Password { get; set; }
       
        public DateTime RegistrationDate { get; set; }
       
        [Required]
        public string Email { get; set; }

    }
}