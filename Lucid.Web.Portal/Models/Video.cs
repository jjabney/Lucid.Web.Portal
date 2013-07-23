using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lucid.Web.Portal.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string MobileUrl { get; set; }

        [Required]
        public string DesktopUrl { get; set; }
    }
}