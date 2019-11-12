using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;
using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data.ReferenceDataRepository
{
    public class ProductsRepository:IProductsRepository
    {
        private readonly string path = @"..\..\..\FlooringOrderingSystem.Data\DataFiles\Products.txt";

        public ProductLookUpResponse ProductLookup(string ProductType)
        {
            bool ProductFound = false;
            ProductLookUpResponse Response = new ProductLookUpResponse
            {
                Success = false,
                Message = "Invalid Product Type, please verify spelling. If valid contact IT",
                Products = null
            };

            Products _products = new Products();

            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                while (((line = reader.ReadLine()) != null) && (!ProductFound))
                {
                    string[] columns = line.Split(',');
                    if (ProductType == columns[0])
                    {
                        ProductFound = true;
                        Response.Success = true;
                        Response.Message = "Product Type is available";
                        _products.ProductType = columns[0];

                        if (decimal.TryParse(columns[1], out decimal CostPerSquareFootRate))
                        {
                            _products.CostPerSquareFoot = CostPerSquareFootRate;

                        }
                        else
                        {
                            Response.Success = false;
                            Response.Message = "Cost Per Square Foot is missing for the product. Contact IT";
                            _products.CostPerSquareFoot = 99.99M;
                        }

                        if (decimal.TryParse(columns[2], out decimal LaborCostPerSquareFootRate))
                        {
                            _products.LaborCostPerSquareFoot = LaborCostPerSquareFootRate;

                        }
                        else
                        {
                            Response.Success = false;
                            Response.Message = "Labor Cost Per Square Foot is missing for the product. Contact IT";
                            _products.LaborCostPerSquareFoot = 99.99M;
                        }

                    }
                }
                Response.Products = _products;
            }

            return Response;
        }

        public ProductsListResponse GetProductsList()
        {
            ProductsListResponse Response = new ProductsListResponse
            {
                Success = false,
                Message = "Product Database missing. Contact IT.",
                ProductsList = null
            };
            

            Products products = new Products();
            List<Products> productsList = new List<Products>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();  // Since the first line is always header row,so we are skipping it
                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    
                    Response.Success = true;
                    Response.Message = "Product List is available";
                    products.ProductType = columns[0];
                    if (decimal.TryParse(columns[1], out decimal CostPerSquareFootRate))
                    {
                        products.CostPerSquareFoot = CostPerSquareFootRate;

                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = "Cost Per Square Foot is missing for one or more product. Contact IT";
                        products.CostPerSquareFoot = 99.99M;
                    }

                    if (decimal.TryParse(columns[2], out decimal LaborCostPerSquareFootRate))
                    {
                        products.LaborCostPerSquareFoot = LaborCostPerSquareFootRate;

                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = "Labor Cost Per Square Foot is missing for one or more product. Contact IT";
                        products.LaborCostPerSquareFoot = 99.99M;
                    }

                    
                    productsList.Add(products);
                    products = new Products();  //initialize products object

                }
            }

            Response.ProductsList = productsList;
            return Response;
        }
    }
}
