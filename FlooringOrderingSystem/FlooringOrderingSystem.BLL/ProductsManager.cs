using FlooringOrderingSystem.Models.Interfaces;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL
{
    public class ProductsManager
    {
        private IProductsRepository _productsRepository;
        public ProductsManager(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public ProductsListResponse GetProductsList()
        {
            ProductsListResponse productsListResponse = _productsRepository.GetProductsList();
            return productsListResponse;
        }

        public ProductLookUpResponse ProductLookup(string ProductType)
        {
            ProductLookUpResponse productLookUpResponse = _productsRepository.ProductLookup(ProductType);
            return productLookUpResponse;
        }

    }
    
}
