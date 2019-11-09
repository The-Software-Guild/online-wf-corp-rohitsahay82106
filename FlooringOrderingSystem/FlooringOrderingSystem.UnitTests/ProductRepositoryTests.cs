using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Data.ReferenceDataRepository;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.UnitTests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        [Test]
        public void GetProductListTest()
        {


            ProductsManager _productsRepository = ProductsManagerFactory.Create();

            ProductsListResponse productsListResponse = _productsRepository.GetProductsList();

            Assert.IsTrue(productsListResponse.Success);

            if (productsListResponse.Success)
            {
                int serialno = 0;
                List<Products> _productsList = productsListResponse.ProductsList;
                foreach (Products product in _productsList)
                {
                    serialno += 1;
                    switch (serialno)
                    {
                        case 1:
                            Assert.AreEqual("Carpet", product.ProductType);
                            break;
                        case 2:
                            Assert.AreEqual("Laminate", product.ProductType);
                            break;
                        default:
                            break;

                    }

                }


            }

        }

        [TestCase("Carpet", 2.25, 2.10, true)]
        [TestCase("Wood", 5.15, 4.75, true)]
        [TestCase("FauxWood", 5.15, 4.75, false)]
        [TestCase("Tile", 3.50, 4.15, true)]
        public void ProductLookupTest(string ProductType, decimal CostPerSquareFeet, decimal LaborCostPerSquareFeet, bool ExpectedResult)
        {

            ProductsManager _productsRepository = ProductsManagerFactory.Create();

            ProductLookUpResponse productLookUpResponse = _productsRepository.ProductLookup(ProductType);
            Assert.AreEqual(ExpectedResult, productLookUpResponse.Success);
            if (productLookUpResponse.Success)
            {
                Assert.AreEqual(CostPerSquareFeet, productLookUpResponse.Products.CostPerSquareFoot);
                Assert.AreEqual(LaborCostPerSquareFeet, productLookUpResponse.Products.LaborCostPerSquareFoot);
            }


        }
    }
}
