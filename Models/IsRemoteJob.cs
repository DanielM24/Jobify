using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobify.Models
{
    public class IsRemoteJob : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var job = (Job)validationContext.ObjectInstance;

            if (job.IsRemote == true)
                return ValidationResult.Success;
            else
                if(job.IsRemote == false)
                    return new ValidationResult("If job is not remote, city is required.");
            return ValidationResult.Success;

        }
    }
}