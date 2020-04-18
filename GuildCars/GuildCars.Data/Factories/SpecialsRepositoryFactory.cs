using System;
using GuildCars.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Data.Repository_Prod;

namespace GuildCars.Data.Factories
{
    public static class SpecialsRepositoryFactory
    {
        public static ISpecialsRepository GetDataRepository()
        {
            switch (Settings.GetModeValue())
            {
                case "PROD":
                    return new SpecialsDataRepository();
                default:
                    throw new Exception("Invalid Mode value in AppSettings");
            }
        }
    }
}
