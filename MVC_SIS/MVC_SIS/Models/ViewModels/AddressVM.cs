using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Models.ViewModels
{
    public class AddressVM
    {
        public int studentid { get; set; }
        [Required(ErrorMessage = "Please enter Street Address")]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please select State")]
        public string StateAbbrv { get; set; }
        [Required(ErrorMessage = "Please enter Postal Zipcode")]
        public string PostalCode { get; set; }
        public List<SelectListItem> StateItems { get; set; }

        public AddressVM()
        {
            StateItems = new List<SelectListItem>();
            
        }


        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateAbbreviation,
                    Text = state.StateName
                });
            }
        }

    }

}