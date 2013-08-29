using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lucid.Web.Portal.Models
{
    public class TreatmentPlan
    {
        public TreatmentPlan()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

        public virtual List<Treatment> Treatments { get; set; }

        
        public List<int> SelectedTreatmentIds{get; set; }	
    }
}