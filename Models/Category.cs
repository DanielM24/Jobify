using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobify.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Category
    {
        public byte CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public byte JobId { get; set; }
        public virtual Job Job { get; set; }

    }
}