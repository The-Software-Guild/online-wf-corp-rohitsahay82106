using FlooringOrderingSystem.Data.ReferenceDataRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL
{
    public class StateTaxManagerFactory
    {
        public static StateTaxManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new StateTaxManager(new TaxDataRepository());
                case "Production":
                    return new StateTaxManager(new TaxDataRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
