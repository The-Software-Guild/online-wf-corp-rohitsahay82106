using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class AddVehicleViewModel : IValidatableObject
    {
        public Vehicles vehicle { get; set; }

        public IEnumerable<SelectListItem> Make { get; set; }
        public IEnumerable<SelectListItem> Type { get; set; }
        public IEnumerable<SelectListItem> BodyStyle { get; set; }
        public IEnumerable<SelectListItem> Trans { get; set; }
        public IEnumerable<SelectListItem> ExteriorColor { get; set; }
        public IEnumerable<SelectListItem> InteriorColor { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (vehicle.VehicleMakeYear < 2000)
            {
                errors.Add(new ValidationResult("Invalid Make Year. Year less than 2000 not allowed"));
            }

            if ((vehicle.VehicleMakeYear - 1) > DateTime.Today.Year)
            {
                errors.Add(new ValidationResult("Invalid Make Year. Make Year too far in future"));
            }

            if ((vehicle.VehicleTypeID == 1) && (vehicle.VehicleMileage > 1000))
            {
                errors.Add(new ValidationResult("Invalid Mileage. New vehicles with more than 1000 miles not allowed"));
            };
            if ((vehicle.VehicleTypeID == 2) && (vehicle.VehicleMileage < 1000))
            {
                errors.Add(new ValidationResult("Invalid Mileage. Used vehicles should have atleast 1000 miles"));
            };
            if(string.IsNullOrEmpty(vehicle.VehicleVinNumber))
            {
                errors.Add(new ValidationResult("VIN number is required"));
            }
            else
            {
                if(vehicle.VehicleVinNumber.Length != 17)
                {
                    errors.Add(new ValidationResult("Invalid VIN number"));
                }
            }
            if (string.IsNullOrEmpty(vehicle.VehicleDescription))
            {
                errors.Add(new ValidationResult("Description is required"));
            }
            if (vehicle.VehicleSalePrice<0 || vehicle.VehicleSalePrice>vehicle.VehicleMSRP)
            {
                errors.Add(new ValidationResult("Invalid Sale price"));
            }
            if (vehicle.VehicleMSRP < 0 ) 
            {
                errors.Add(new ValidationResult("Invalid MSRP"));
            }
            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".jpeg" };
                string extension = Path.GetExtension(ImageUpload.FileName);
                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, or jpeg."));
                }
            }
            else
            {
                errors.Add(new ValidationResult("Image file is required"));
            }


            return errors;
        }
    }

    public class EditVehicleViewModel:IValidatableObject
    {
        public Vehicles vehicle { get; set; }
        public int VehicleMakeID { get; set; }

        public IEnumerable<SelectListItem> Make { get; set; }
        public IEnumerable<SelectListItem> Model { get; set; }
        public IEnumerable<SelectListItem> Type { get; set; }
        public IEnumerable<SelectListItem> BodyStyle { get; set; }
        public IEnumerable<SelectListItem> Trans { get; set; }
        public IEnumerable<SelectListItem> ExteriorColor { get; set; }
        public IEnumerable<SelectListItem> InteriorColor { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (vehicle.VehicleMakeYear < 2000)
            {
                errors.Add(new ValidationResult("Invalid Make Year. Year less than 2000 not allowed"));
            }

            if ((vehicle.VehicleMakeYear - 1) > DateTime.Today.Year)
            {
                errors.Add(new ValidationResult("Invalid Make Year. Make Year too far in future"));
            }

            if ((vehicle.VehicleTypeID == 1) && (vehicle.VehicleMileage > 1000))
            {
                errors.Add(new ValidationResult("Invalid Mileage. New vehicles with more than 1000 miles not allowed"));
            };
            if ((vehicle.VehicleTypeID == 2) && (vehicle.VehicleMileage < 1000))
            {
                errors.Add(new ValidationResult("Invalid Mileage. Used vehicles should have atleast 1000 miles"));
            };
            if (string.IsNullOrEmpty(vehicle.VehicleVinNumber))
            {
                errors.Add(new ValidationResult("VIN number is required"));
            }
            else
            {
                if (vehicle.VehicleVinNumber.Length != 17)
                {
                    errors.Add(new ValidationResult("Invalid VIN number"));
                }
            }
            if (string.IsNullOrEmpty(vehicle.VehicleDescription))
            {
                errors.Add(new ValidationResult("Description is required"));
            }
            if (vehicle.VehicleSalePrice < 0 || vehicle.VehicleSalePrice > vehicle.VehicleMSRP)
            {
                errors.Add(new ValidationResult("Invalid Sale price"));
            }
            if (vehicle.VehicleMSRP < 0)
            {
                errors.Add(new ValidationResult("Invalid MSRP"));
            }
            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".jpeg" };
                string extension = Path.GetExtension(ImageUpload.FileName);
                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, or jpeg."));
                }
            }
            


            return errors;
        }

    }

    public class VehicleMakeViewModel
    {
        public List<MakeVM> vehicleMakes { get; set; }
         
        public VehicleMake newMake { get; set; }
    }
    public class MakeVM
    {
        public string Make { get; set; }
        public string DateAdded { get; set; }
        public string Email { get; set; }
    }

    public class VehicleModelViewModel
    {
        public List<ModelVM> vehicleModels { get; set; }
        public IEnumerable<SelectListItem> Make { get; set; }
        public VehicleMakeModel newModel { get; set; }
    }
    public class ModelVM
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string DateAdded { get; set; }
        public string Email { get; set; }
    }

    public class SpecialsViewModel:IValidatableObject
    {
        public IEnumerable<Specials> specials { get; set; }

        public Specials newSpecial { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if(string.IsNullOrEmpty(newSpecial.SpecialsTitle))
            {
                errors.Add(new ValidationResult("Title is required"));
            }
            if (string.IsNullOrEmpty(newSpecial.SpecialsDescription))
            {
                errors.Add(new ValidationResult("Description is required"));
            }

            return errors;
        }
    }

    public class UsersViewModel
    {
        public string UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
    }
    public class AddUserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string RoleName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }

    public class EditUserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string RoleName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
        public string UserId { get; set; }
    }

    
}