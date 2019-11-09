using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Responses
{
    public class ProductsListResponse: Response
    {
        public List<Products> ProductsList = new List<Products>();
    }
}
