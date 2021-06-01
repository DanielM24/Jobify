using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobify.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicantJob
    {
        [Key, Column(Order = 1)]
        public byte ApplicantId { get; set; }
        [Key, Column(Order = 2)]
        public byte JobId { get; set; }
        public Applicant Applicant { get; set; }
        public Job Job { get; set; }
    }
}