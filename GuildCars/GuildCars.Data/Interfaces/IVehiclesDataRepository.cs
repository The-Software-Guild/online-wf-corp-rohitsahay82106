using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehiclesDataRepository
    {
        void AddNewVehicle(Vehicles vehicle);
        void EditVehicle(Vehicles vehicle);
        void DeleteVehicle(int id);
        List<VehicleShortSearch> GetAllFeaturedVehicles();
        VehicleLongSearch GetVehicleByID(int id);
        void AddNewVehicleMake(VehicleMake vehicleMake);
        void AddNewVehicleMakeModel(VehicleMakeModel vehicleMakeModel);
        IEnumerable<VehicleMake> GetAllVehicleMake();
        IEnumerable<VehicleMakeModelSearch> GetAllVehicleMakeModel();
        IEnumerable<VehicleLongSearch> VehicleSearchResult(VehicleSearchParameters parameters, string type);
        IEnumerable<VehicleMakeModel> GetVehicleModels(int MakeID);
        Vehicles GetVehicleForEdit(int id);
        int GetVehicleMakeID(int id);
        IEnumerable<InventoryReport> GetInventoryReports(int VehicleTypeID);

    }
}
