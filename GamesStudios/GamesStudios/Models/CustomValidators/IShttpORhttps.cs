using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesStudios.Models.CustomValidators
{
    public class IShttpORhttps : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var game = (Game) validationContext.ObjectInstance;

            Uri uriResult;

            if (Uri.TryCreate(game.DownloadLink, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The URL is not Valid");
            }
        }
    }
}