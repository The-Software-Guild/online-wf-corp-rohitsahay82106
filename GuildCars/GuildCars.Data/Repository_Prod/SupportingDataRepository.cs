using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository_Prod
{
    public class SupportingDataRepository : ISupportingDataRepository
    {
            
        public VehicleTransmissionType GetVehicleTransmissionType(int id)
        {
            VehicleTransmissionType vehicleTransmissionType = new VehicleTransmissionType();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetVehicleTransmissionType", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if(dr.Read())
                    {
                        
                        vehicleTransmissionType.VehicleTransmissionTypeDesc = dr["VehicleTransmissionTypeDesc"].ToString();
                    }
                }
            }

            return vehicleTransmissionType;
        }

        public List<PurchaseType> GetAllPurchaseType()
        {
            List<PurchaseType> outList = new List<PurchaseType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllPurchaseType", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType row = new PurchaseType();
                        row.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        row.PurchaseTypeDesc = dr["PurchaseTypeDesc"].ToString();
                        outList.Add(row);
                    }
                }
            }

            return outList;
        }

        public List<States> GetAllStates()
        {
            List<States> outList = new List<States>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllStates", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        States row = new States();
                        row.StateID = dr["StateID"].ToString();
                        row.StateName = dr["StateName"].ToString();
                        outList.Add(row);
                    }
                }
            }

            return outList;
        }

        public List<VehicleBodyType> GetAllVehicleBodyType()
        {
            List<VehicleBodyType> outList = new List<VehicleBodyType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllVehicleBodyType", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleBodyType row = new VehicleBodyType();
                        row.VehicleBodyTypeID = (int)dr["VehicleBodyTypeID"];
                        row.VehicleBodyTypeDesc = dr["VehicleBodyTypeDesc"].ToString();
                        outList.Add(row);
                    }
                }
            }

            return outList;
        }

        public List<VehicleExteriorColor> GetAllVehicleExteriorColor()
        {
            List<VehicleExteriorColor> outList = new List<VehicleExteriorColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllVehicleExteriorColor", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleExteriorColor row = new VehicleExteriorColor();
                        row.VehicleExteriorColorID = (int)dr["VehicleExteriorColorID"];
                        row.VehicleExteriorColorDesc = dr["VehicleExteriorColorDesc"].ToString();
                        outList.Add(row);
                    }
                }
            }

            return outList;
        }

        public List<VehicleInteriorColor> GetAllVehicleInteriorColor()
        {
            List<VehicleInteriorColor> outList = new List<VehicleInteriorColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllVehicleInteriorColor", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleInteriorColor row = new VehicleInteriorColor();
                        row.VehicleInteriorColorID = (int)dr["VehicleInteriorColorID"];
                        row.VehicleInteriorColorDesc = dr["VehicleInteriorColorDesc"].ToString();
                        outList.Add(row);
                    }
                }
            }

            return outList;
        }

        public List<VehicleTransmissionType> GetAllVehicleTransmissionType()
        {
            List<VehicleTransmissionType> outList = new List<VehicleTransmissionType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllVehicleTransmissionType", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleTransmissionType row = new VehicleTransmissionType();
                        row.VehicleTransmissionTypeID = (int)dr["VehicleTransmissionTypeID"];
                        row.VehicleTransmissionTypeDesc = dr["VehicleTransmissionTypeDesc"].ToString();
                        outList.Add(row);
                    }
                }
            }

            return outList;
        }

        public List<VehicleType> GetAllVehicleType()
        {
            List<VehicleType> outList = new List<VehicleType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllVehicleType", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleType row = new VehicleType();
                        row.VehicleTypeID = (int)dr["VehicleTypeID"];
                        row.VehicleTypeDesc = dr["VehicleTypeDesc"].ToString();
                        outList.Add(row);
                    }
                }
            }

            return outList;
        }
    }
}
