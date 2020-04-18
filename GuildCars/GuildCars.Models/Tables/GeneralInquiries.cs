using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class GeneralInquiries
    {
        public int GeneralInquiriesID { get; set; }
        public string InquiringEntityName { get; set; }
        public string InquiringEntityEmail { get; set; }
        public string InquiringEntityPhone { get; set; }
        public string GeneralInquiryMessage { get; set; }
        public DateTime GeneralInquiryLogDate { get; set; }

        
    }
}
