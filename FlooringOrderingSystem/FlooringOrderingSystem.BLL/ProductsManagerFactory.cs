using FlooringOrderingSystem.Data.ReferenceDataRepository;
using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL
{
    public class ProductsManagerFactory
    {
        public static ProductsManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new ProductsManager(new ProductsRepository());
                case "Production":
                    return new ProductsManager(new ProductsRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
