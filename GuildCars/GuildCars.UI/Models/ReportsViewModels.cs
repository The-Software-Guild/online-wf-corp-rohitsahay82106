using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class InventoryReportsViewModels
    {
        public IEnumerable<InventoryReport> newInventory { get; set; }
        public IEnumerable<InventoryReport> usedInventory { get; set; }
    }
}