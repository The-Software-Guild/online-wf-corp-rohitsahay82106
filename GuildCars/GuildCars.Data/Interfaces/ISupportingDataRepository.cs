using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISupportingDataRepository
    {
        VehicleTransmissionType GetVehicleTransmissionType(int id);
        List<VehicleTransmissionType> GetAllVehicleTransmissionType();
        List<VehicleBodyType> GetAllVehicleBodyType();
        List<VehicleType> GetAllVehicleType();
        List<VehicleExteriorColor> GetAllVehicleExteriorColor();
        List<VehicleInteriorColor> GetAllVehicleInteriorColor();
        List<States> GetAllStates();
        List<PurchaseType> GetAllPurchaseType();

    }
}
