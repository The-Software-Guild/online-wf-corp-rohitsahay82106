using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD.Models.Tables
{
    public class Dvd
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public short ReleaseYear { get; set; }
        public string Director { get; set; }
        public string RatingId { get; set; }
        public string Notes { get; set; }

        public virtual Rating Rating { get; set; }

    }
}
