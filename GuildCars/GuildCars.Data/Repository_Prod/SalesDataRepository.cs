using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
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
    public class SalesDataRepository : ISalesDataRepository
    {
        public void LogGeneralInquiry(GeneralInquiries generalInquiries)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GeneralInquiriesID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@InquiringEntityName", generalInquiries.InquiringEntityName);
                parameters.Add("@InquiringEntityEmail", generalInquiries.InquiringEntityEmail);
                parameters.Add("@InquiringEntityPhone", generalInquiries.InquiringEntityPhone);
                parameters.Add("@GeneralInquiryMessage", generalInquiries.GeneralInquiryMessage);

                cn.Execute("LogGeneralInquiry", parameters, commandType: CommandType.StoredProcedure);
                generalInquiries.GeneralInquiriesID = parameters.Get<int>("@GeneralInquiriesID");
            }
        }

        public void PurchaseVehicle(VehiclePurchaseData vehiclePurchaseData)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AddressID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@StreetAddressLine1", vehiclePurchaseData.StreetAddressLine1);
                parameters.Add("@StreetAddressLine2", vehiclePurchaseData.StreetAddressLine2);
                parameters.Add("@City", vehiclePurchaseData.City);
                parameters.Add("@ZipCode", vehiclePurchaseData.ZipCode);
                parameters.Add("@StateID", vehiclePurchaseData.StateID);


                parameters.Add("@CustomerFullName", vehiclePurchaseData.CustomerFullName);
                parameters.Add("@CustomerEmailAddress", vehiclePurchaseData.CustomerEmailAddress);
                parameters.Add("@CustomerPhoneNumber", vehiclePurchaseData.CustomerPhoneNumber);

                parameters.Add("@VehicleID", vehiclePurchaseData.VehicleID);
                parameters.Add("@UserID", vehiclePurchaseData.UserID);
                parameters.Add("@PurchasePrice", vehiclePurchaseData.PurchasePrice);
                parameters.Add("@PurchaseTypeID", vehiclePurchaseData.PurchaseTypeID);


                parameters.Add("@CustomerID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@SaleID", dbType: DbType.Int32, direction: ParameterDirection.Output);


                cn.Execute("PurchaseVehicle", parameters, commandType: CommandType.StoredProcedure);
                
            }


        }

        public IEnumerable<SalesReport> SalesSearchResult(SalesSearchParameters parameters)
        {
            IEnumerable<SalesReport> resultSet = new List<SalesReport>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var dynamicParameters = new DynamicParameters();

                string sql = "Select FirstName, LastName, Sum(PurchasePrice) AS TotalSales, " +
                             "Count(SaleID) AS TotalVehicles " +
                            "From AllSalesRecord Where 1=1 ";

                if (!string.IsNullOrEmpty(parameters.UserName))
                {
                    sql += "And UserName=@UserName ";
                    dynamicParameters.Add("@UserName", parameters.UserName);
                }
                if (parameters.FromDate.HasValue)
                {
                    sql += "And SaleDate>=@FromDate ";
                    dynamicParameters.Add("@FromDate", parameters.FromDate.Value);
                }
                if (parameters.ToDate.HasValue)
                {
                    sql += "And SaleDate<=@ToDate ";
                    dynamicParameters.Add("@ToDate", parameters.ToDate.Value);
                }
                
                sql += "Group By FirstName, LastName Order by FirstName ";
                resultSet = cn.Query<SalesReport>(sql, dynamicParameters, commandType: CommandType.Text);

            }

            return resultSet;
        }
    }
}
