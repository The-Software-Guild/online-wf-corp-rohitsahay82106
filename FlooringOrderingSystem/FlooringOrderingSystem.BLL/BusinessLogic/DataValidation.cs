using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;
using FlooringOrderingSystem.Data.ReferenceDataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL.BusinessLogic
{
    public class DataValidation
    {
        Response response = new Response();
        
        public Response ValidateOrderData(Order Order, out decimal CostPerSquareFoot,  out decimal LaborCostPerSquareFoot, out decimal TaxRate)
        {
            
            CostPerSquareFoot = 0;
            LaborCostPerSquareFoot = 0;
            TaxRate = 0;

            
            response = ValidateCustomerName(Order.CustomerName);
            if (!response.Success)
            {
                return response;
            }

            response = ValidateOrderDate(Order.OrderDate);
            if (!response.Success)
            {
                return response;
            }

            response = ValidateStateCode(Order.State, out TaxRate);
            if (!response.Success)
            {
                return response;
            }

            response = ValidateArea(Order.Area);
            if (!response.Success)
            {
                return response;
            }

            
            ProductsManager _productsRepository = ProductsManagerFactory.Create();
            ProductLookUpResponse productLookUpResponse = _productsRepository.ProductLookup(Order.ProductType);
            if (!productLookUpResponse.Success)
            {
                response.Success = false;
                response.Message = "Product Type not found";
                return response;
            }


            CostPerSquareFoot = productLookUpResponse.Products.CostPerSquareFoot;
            LaborCostPerSquareFoot = productLookUpResponse.Products.LaborCostPerSquareFoot;
            

            response.Success = true;
            response.Message = "Order data passed all validations";

            return response; 
        }

        public Response ValidateStateCode(string State, out decimal TaxRate)
        {
            TaxRate = 0;
            StateTaxManager _taxDataRepository = StateTaxManagerFactory.Create();
            StateTaxLookUpResponse stateTaxLookUpResponse = _taxDataRepository.TaxRateLookup(State);
            if (!stateTaxLookUpResponse.Success)
            {
                response.Success = false;
                response.Message = "We do not do Business in this state";
                
            }
            else
            {
                response.Success = true;
                response.Message = "Valid State";
                TaxRate = stateTaxLookUpResponse.TaxData.TaxRate;
            }

            return response;
        }

        public Response ValidateCustomerName(string CustomerName)
        {
            response.Success = false;
            response.Message = "Invalid characters in Customer Name";

            if (CustomerName.Length == 0)
            {
                response.Success = false;
                response.Message = "Customer Name cannot be empty";
                return response;
            }

            char[] c = CustomerName.ToCharArray();
            foreach(char a in c)
            {
                if ((char.IsLetterOrDigit(a))||(a == ',')||(a == '.')) 
                {
                    response.Success = true;
                    response.Message = "Customer Name passed all validation";
                }
                else if (!char.IsWhiteSpace(a))
                {
                    response.Success = false;
                    response.Message = "Invalid characters in Customer Name";
                    return response;
                }
                    
            }

            return response;

        }

        public Response ValidateArea(decimal Area)
        {
            
            if (Area<100)
            {
                response.Success = false;
                response.Message = "Area must be 100 or greater";

            }
            else
            {
                response.Success = true;
                response.Message = "Area passed validation";
                
            }

            return response;
        }

        public Response ValidateOrderDate(DateTime OrderDate)
        {

            if (OrderDate.Year > DateTime.Today.Year)
            {
                response.Success = true;
                response.Message = "Order Date passed all validation";
                return response;
            }

            if (OrderDate.Year < DateTime.Today.Year)
            {
                response.Success = false;
                response.Message = "Order Date cannot be in past";
                return response;
            }

            if (OrderDate.Month > DateTime.Today.Month)
            {
                response.Success = true;
                response.Message = "Order Date passed all validation";
                return response;
            }

            if (OrderDate.Month < DateTime.Today.Month)
            {
                response.Success = false;
                response.Message = "Order Date cannot be in past";
                return response;
            }

            
            if (OrderDate.Day < DateTime.Today.Day)
            {
                response.Success = false;
                response.Message = "Order Date cannot be in past";
                return response;
            }
            
            response.Success = true;
            response.Message = "Order Date passed all validation";
            return response;
        }

    }
}
