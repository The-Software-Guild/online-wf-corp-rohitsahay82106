using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State
    {
        [Required(ErrorMessage = "Please two character State Abbreviation")]
        public string StateAbbreviation { get; set; }
        [Required(ErrorMessage = "Please enter Full State Name")]
        public string StateName { get; set; }
    }
}