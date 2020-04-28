using DVD.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVD_Catalogue.Models
{
    public class DvdCatalogEntity : DbContext
    {
        public DvdCatalogEntity() : base("DvdCatalog")
        {
        }

        public DbSet<Dvd> Dvd { get; set; }
        public DbSet<Rating> Rating { get; set; }

    }
}