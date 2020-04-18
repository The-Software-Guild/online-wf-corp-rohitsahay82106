using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISalesDataRepository
    {
        void PurchaseVehicle(VehiclePurchaseData vehiclePurchaseData);
        void LogGeneralInquiry(GeneralInquiries generalInquiries);
        IEnumerable<SalesReport> SalesSearchResult(SalesSearchParameters parameters);
    }
}
