using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GamesStudios.Helpers
{
    public class TestModelHelper
    {
        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);
            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
            return results;
        }
    }
}