using GuildCars.Models.Queries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class PurchaseViewModel: IValidatableObject
    {
        public VehicleLongSearch VehicleDetails { get; set; }
        public VehiclePurchaseData vehiclePurchaseData { get; set; }
        public IEnumerable<SelectListItem> states { get; set; }
        public IEnumerable<SelectListItem> purchaseTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(vehiclePurchaseData.StreetAddressLine1))
            {
                errors.Add(new ValidationResult("Street address line 1 is required"));
            }

            if (string.IsNullOrEmpty(vehiclePurchaseData.City))
            {
                errors.Add(new ValidationResult("City is required"));
            }

            if (string.IsNullOrEmpty(vehiclePurchaseData.ZipCode))
            {
                errors.Add(new ValidationResult("ZipCode is required"));
            }
            else 
            {
                if((vehiclePurchaseData.ZipCode.Length < 5) ||(vehiclePurchaseData.ZipCode.Length > 5)) 
                {
                    errors.Add(new ValidationResult("ZipCode must be five digit long"));
                }
            }

            
            if (string.IsNullOrEmpty(vehiclePurchaseData.CustomerFullName))
            {
                errors.Add(new ValidationResult("Customer Name is required"));
            }

            if(string.IsNullOrEmpty(vehiclePurchaseData.CustomerPhoneNumber) && 
                string.IsNullOrEmpty(vehiclePurchaseData.CustomerEmailAddress))
            {
                errors.Add(new ValidationResult("Either Phone or Email is required"));
            }

                        
            if (!string.IsNullOrEmpty(vehiclePurchaseData.CustomerEmailAddress))
            {
                var a = new EmailAddressAttribute();
                if (!a.IsValid(vehiclePurchaseData.CustomerEmailAddress))
                {
                    errors.Add(new ValidationResult("Invalid Email address"));
                }
            }

            
            if (vehiclePurchaseData.PurchasePrice < VehicleDetails.VehicleSalePrice * 0.95M)
            {
                errors.Add(new ValidationResult("Max allowed discount is 5% "));
            }

            if (vehiclePurchaseData.PurchasePrice > VehicleDetails.VehicleMSRP)
            {
                errors.Add(new ValidationResult("Cannot Sale for more than MSRP "));
            }

            return errors;
        }
    }
}