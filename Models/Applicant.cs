using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobify.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Applicant
    {
        public byte ApplicantId { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"\b([A-ZÀ-ÿ][-, a-z. ']+[ ]*)+$", ErrorMessage = "Name format invalid.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w-\.]+@([\w -]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        public virtual ApplicantDetails ApplicantDetails { get; set; }

    }
}