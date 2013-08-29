using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lucid.Web.Portal.Models
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public string Url { get; set; }

        public virtual TreatmentPlan TreatmentPlan { get; set; }

       public bool IsSelected { get; set; }
    }
}