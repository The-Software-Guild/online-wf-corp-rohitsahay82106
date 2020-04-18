using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Repository_Prod;

namespace GuildCars.Data.Factories
{
    public static class SupportingDataRepositoryFactory
    {
        public static ISupportingDataRepository GetDataRepository()
        {
            switch (Settings.GetModeValue())
            {
                case "PROD":
                    return new SupportingDataRepository();
                default:
                    throw new Exception("Invalid Mode value in AppSettings");
            }
        }
    }
}
