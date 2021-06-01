using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobify.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Job
    {
        public byte JobId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Job Title")]
        public string JobName { get; set; }
        [Required]
        [Display(Name ="Description")]
        public string JobDescription { get; set; }
        [Required]
        [Range(1,99)]
        [Display(Name ="Duration (in months)")]
        public int DurationInMonths { get; set; }
        [Required]
        [RegularExpression(@"^([1-9][0-9]*)\$$", ErrorMessage ="Salary Format: ___$")]
        [Display(Name ="Salary (in $)")]
        public string Salary { get; set; }

        [IsRemoteJob]
        [Display(Name ="City")]
        public string City { get; set; }
        [Required]
        [Display(Name ="Remote")]
        public bool IsRemote { get; set; }
        public byte CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Categories")]
        public ICollection<Category>Categories { get; set; }

    }
}