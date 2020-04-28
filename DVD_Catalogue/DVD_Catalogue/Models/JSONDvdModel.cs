using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVD_Catalogue.Models
{
    public class JSONDvdModel
    {
        public int dvdId { get; set; }
        public string title { get; set; }
        public short releaseYear { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public string notes { get; set; }
    }
}