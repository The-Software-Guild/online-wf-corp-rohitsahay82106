using System;
using GuildCars.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Data.Repository_Prod;

namespace GuildCars.Data.Factories
{
    public static class VehiclesRepositoryFactory
    {
        public static IVehiclesDataRepository GetDataRepository()
        {
            switch(Settings.GetModeValue())
            {
                case "PROD":
                    return new VehiclesDataRepository();
                default:
                    throw new Exception("Invalid Mode value in AppSettings");
            }
        }
    }
}
