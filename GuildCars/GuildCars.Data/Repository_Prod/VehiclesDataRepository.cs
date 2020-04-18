using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository_Prod
{
    public class VehiclesDataRepository : IVehiclesDataRepository
    {
        public void AddNewVehicle(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@VehicleVinNumber", vehicle.VehicleVinNumber);
                parameters.Add("@VehicleMakeModelID", vehicle.VehicleMakeModelID);
                parameters.Add("@VehicleMakeYear", vehicle.VehicleMakeYear);
                parameters.Add("@VehicleTypeID", vehicle.VehicleTypeID);
                parameters.Add("@VehicleTransmissionTypeID", vehicle.VehicleTransmissionTypeID);
                parameters.Add("@VehicleBodyTypeID", vehicle.VehicleBodyTypeID);
                parameters.Add("@VehicleExteriorColorID", vehicle.VehicleExteriorColorID);
                parameters.Add("@VehicleInteriorColorID", vehicle.VehicleInteriorColorID);
                parameters.Add("@VehicleMileage", vehicle.VehicleMileage);
                parameters.Add("@VehicleMSRP", vehicle.VehicleMSRP);
                parameters.Add("@VehicleSalePrice", vehicle.VehicleSalePrice);
                parameters.Add("@VehicleDescription", vehicle.VehicleDescription);
                parameters.Add("@VehicleImageFileName", vehicle.VehicleImageFileName);

                cn.Execute("AddNewVehicle", parameters, commandType: CommandType.StoredProcedure);

                vehicle.VehicleID = parameters.Get<int>("@VehicleID");
            }
        }

        public void AddNewVehicleMake(VehicleMake vehicleMake)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleMakeID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@VehicleMakeDesc", vehicleMake.VehicleMakeDesc);
                parameters.Add("@UserId", vehicleMake.UserID);
                
                cn.Execute("AddNewVehicleMake", parameters, commandType: CommandType.StoredProcedure);

                vehicleMake.VehicleMakeID = parameters.Get<int>("@VehicleMakeID");
            }
        }

        public void AddNewVehicleMakeModel(VehicleMakeModel vehicleMakeModel)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleMakeModelID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@VehicleModelDesc", vehicleMakeModel.VehicleModelDesc);
                parameters.Add("@UserId", vehicleMakeModel.UserID);
                parameters.Add("@VehicleMakeID", vehicleMakeModel.VehicleMakeID);

                cn.Execute("AddNewVehicleMakeModel", parameters, commandType: CommandType.StoredProcedure);

                vehicleMakeModel.VehicleMakeModelID = parameters.Get<int>("@VehicleMakeModelID");
            } 
        }

        public void DeleteVehicle(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleID", id);
                cn.Execute("DeleteVehicle",parameters, commandType: CommandType.StoredProcedure);
            }
        }

        
        public VehicleLongSearch GetVehicleByID(int id)
        {
            VehicleLongSearch vehicleLongSearch = new VehicleLongSearch();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleID", id);
                vehicleLongSearch = cn.Query<VehicleLongSearch>("GetVehicleByID",
                                    parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }

            return vehicleLongSearch;
        }

        public List<VehicleShortSearch> GetAllFeaturedVehicles()
        {
            List<VehicleShortSearch> vehicleShortSearch = new List<VehicleShortSearch>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                
                vehicleShortSearch = cn.Query<VehicleShortSearch>("GetAllFeaturedVehicles",
                                    commandType: CommandType.StoredProcedure).ToList();
                
            }

            return vehicleShortSearch;
        }

        public void EditVehicle(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleID", vehicle.VehicleID);
                parameters.Add("@VehicleVinNumber", vehicle.VehicleVinNumber);
                parameters.Add("@VehicleMakeModelID", vehicle.VehicleMakeModelID);
                parameters.Add("@VehicleMakeYear", vehicle.VehicleMakeYear);
                parameters.Add("@VehicleTypeID", vehicle.VehicleTypeID);
                parameters.Add("@VehicleTransmissionTypeID", vehicle.VehicleTransmissionTypeID);
                parameters.Add("@VehicleBodyTypeID", vehicle.VehicleBodyTypeID);
                parameters.Add("@VehicleExteriorColorID", vehicle.VehicleExteriorColorID);
                parameters.Add("@VehicleInteriorColorID", vehicle.VehicleInteriorColorID);
                parameters.Add("@VehicleMileage", vehicle.VehicleMileage);
                parameters.Add("@VehicleMSRP", vehicle.VehicleMSRP);
                parameters.Add("@VehicleSalePrice", vehicle.VehicleSalePrice);
                parameters.Add("@VehicleDescription", vehicle.VehicleDescription);
                parameters.Add("@VehicleImageFileName", vehicle.VehicleImageFileName);
                parameters.Add("@VehicleOnFeaturedList", vehicle.VehicleOnFeaturedList);

                cn.Execute("EditVehicle", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public IEnumerable<VehicleMake> GetAllVehicleMake()
        {
            IEnumerable<VehicleMake> vehicleMakes = new List<VehicleMake>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                vehicleMakes = cn.Query<VehicleMake>("GetAllVehicleMake",
                                    commandType: CommandType.StoredProcedure);

            }

            return vehicleMakes;
        }

        public IEnumerable<VehicleMakeModelSearch> GetAllVehicleMakeModel()
        {
            IEnumerable<VehicleMakeModelSearch> vehicleMakeModels = new List<VehicleMakeModelSearch>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                vehicleMakeModels = cn.Query<VehicleMakeModelSearch>("GetAllVehicleMakeModel",
                                    commandType: CommandType.StoredProcedure);

            }

            return vehicleMakeModels;
        }

        public IEnumerable<VehicleLongSearch> VehicleSearchResult(VehicleSearchParameters parameters, string type = "New")
        {
            IEnumerable<VehicleLongSearch> resultSet = new List<VehicleLongSearch>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var dynamicParameters = new DynamicParameters();

                string sql = "Select Top 20 VehicleID, VehicleDescription, VehicleSalePrice, VehicleMSRP, " +
                                "VehicleVinNumber, VehicleImageFileName, VehicleMakeYear, VehicleTypeDesc, " +
                                "VehicleTransmissionTypeDesc, VehicleBodyTypeDesc, VehicleModelDesc, VehicleMakeDesc, " +
                                "VehicleMileage, VehicleExteriorColorDesc, VehicleInteriorColorDesc "+
                                "From AllAvailableVehicles Where 1=1 ";

                if(type != "All")
                {
                    sql += "And VehicleTypeDesc = @VehicleType ";
                    dynamicParameters.Add("@VehicleType", type);
                }
                
                
                if (parameters.MinPrice.HasValue)
                {
                    sql += "And VehicleSalePrice>=@MinPrice ";
                    dynamicParameters.Add("@MinPrice", parameters.MinPrice.Value);
                }
                if (parameters.MaxPrice.HasValue)
                {
                    sql += "And VehicleSalePrice<=@MaxPrice ";
                    dynamicParameters.Add("@MaxPrice", parameters.MaxPrice.Value);
                }
                if (parameters.MinYear.HasValue)
                {
                    sql += "And VehicleMakeYear>=@MinYear ";
                    dynamicParameters.Add("@MinYear", parameters.MinYear.Value);
                }
                if (parameters.MaxYear.HasValue)
                {
                    sql += "And VehicleMakeYear<=@MaxYear ";
                    dynamicParameters.Add("@MaxYear", parameters.MaxYear.Value);
                }
                if (!string.IsNullOrEmpty(parameters.QuickSearch))
                {
                    sql += "And (VehicleMakeDesc Like @QuickSearch OR VehicleModelDesc Like @QuickSearch OR VehicleMakeYear Like @QuickSearch) ";
                    dynamicParameters.Add("@QuickSearch", parameters.QuickSearch + "%");
                }

                sql += "Order by VehicleSalePrice Desc ";
                resultSet = cn.Query<VehicleLongSearch>(sql,dynamicParameters, commandType: CommandType.Text);

            }

            return resultSet;
        }

        public IEnumerable<VehicleMakeModel> GetVehicleModels(int MakeID)
        {
            IEnumerable<VehicleMakeModel> vehicleMakeModels = new List<VehicleMakeModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@VehicleMakeID", MakeID);    

                vehicleMakeModels = cn.Query<VehicleMakeModel>("GetVehicleModels", dynamicParameters,
                                    commandType: CommandType.StoredProcedure);

            }

            return vehicleMakeModels;
        }

        public Vehicles GetVehicleForEdit(int id)
        {
            Vehicles vehicle = new Vehicles();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleID", id);
                vehicle = cn.Query<Vehicles>("GetVehicleForEdit",
                                    parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }

            return vehicle;
        }

        public int GetVehicleMakeID(int id)
        {
            int vehicleMakeID; 
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleMakeModelID", id);
                vehicleMakeID = cn.Query<int>("GetVehicleMakeID",
                                    parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }

            return vehicleMakeID;
        }

        public IEnumerable<InventoryReport> GetInventoryReports(int VehicleTypeID)
        {
            IEnumerable<InventoryReport> inventoryReports = new List<InventoryReport>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleTypeID", VehicleTypeID);
                inventoryReports = cn.Query<InventoryReport>("GetInventoryReports",
                                            parameters, commandType: CommandType.StoredProcedure);

            }

            return inventoryReports;
        }
    }
}
