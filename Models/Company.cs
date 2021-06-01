using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobify.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Company
    {
        public byte CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}