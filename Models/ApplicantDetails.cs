using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobify.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class ApplicantDetails
    {
        [ForeignKey("Applicant")]
        public byte ApplicantDetailsId { get; set; }

        [Required]
        [RegularExpression(@" ^ (\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\s|\.|\-)?([0-9]{3}(\s|\.|\-|)){2}$", ErrorMessage = "Invalid phone number format")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public int Age { get; set; }
        public string Bio { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string Projects { get; set; }
        public string Languages { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}