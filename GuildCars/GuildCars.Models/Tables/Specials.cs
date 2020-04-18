using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Specials
    {
        public int SpecialsID { get; set; }
        public string SpecialsTitle { get; set; }
        public string SpecialsDescription { get; set; }
        public DateTime SpecialsEffectiveDate { get; set; }
        public DateTime SpecialsExpirationDate { get; set; }
    }
}
