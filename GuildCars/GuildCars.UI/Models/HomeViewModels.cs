using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Specials> Specials { get; set; }
        public IEnumerable<VehicleShortSearch> FeaturedVehicles { get; set; }
    }
    public class ContactViewModel : IValidatableObject
    {
        public GeneralInquiries Inquiries { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Inquiries.InquiringEntityName))
            {
                errors.Add(new ValidationResult("Name is required"));
            }

            if (string.IsNullOrEmpty(Inquiries.GeneralInquiryMessage))
            {
                errors.Add(new ValidationResult("Message is required"));
            }

            if (string.IsNullOrEmpty(Inquiries.InquiringEntityEmail) && (string.IsNullOrEmpty(Inquiries.InquiringEntityPhone)))
            {
                errors.Add(new ValidationResult("Either Email or Phone is required"));
            }

            if (!string.IsNullOrEmpty(Inquiries.InquiringEntityEmail))
            {
                var a = new EmailAddressAttribute();
                if (!a.IsValid(Inquiries.InquiringEntityEmail))
                {
                    errors.Add(new ValidationResult("Invalid Email address"));
                }
            }

            return errors;
        }
    }
}