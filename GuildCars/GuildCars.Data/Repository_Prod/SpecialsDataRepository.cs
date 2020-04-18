using System;
using Dapper;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository_Prod
{
    public class SpecialsDataRepository : ISpecialsRepository
    {
        public void AddNewSpecials(Specials specials)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SpecialsID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@SpecialsTitle", specials.SpecialsTitle);
                parameters.Add("@SpecialsDescription", specials.SpecialsDescription);

                cn.Execute("AddNewSpecials", parameters, commandType: CommandType.StoredProcedure);

                specials.SpecialsID = parameters.Get<int>("@SpecialsID");
            }
        }

        public void DeleteSpecials(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SpecialsID", id);
                cn.Execute("DeleteSpecials", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Specials> GetAllSpecials()
        {
            IEnumerable<Specials> specials = new List<Specials>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                specials = cn.Query<Specials>("GetAllSpecials",
                                    commandType: CommandType.StoredProcedure);

            }

            return specials;
        }
    }
}
