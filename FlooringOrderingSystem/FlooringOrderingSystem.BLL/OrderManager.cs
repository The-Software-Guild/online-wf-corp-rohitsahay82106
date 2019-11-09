using FlooringOrderingSystem.Models.Interfaces;
using FlooringOrderingSystem.Models.Responses;
using FlooringOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Data.ReferenceDataRepository;
using FlooringOrderingSystem.BLL.BusinessLogic;

namespace FlooringOrderingSystem.BLL
{
    public class OrderManager
    {
        private IOrdersInventory _ordersInventory;
        public OrderManager(IOrdersInventory ordersInventory)
        {
            _ordersInventory = ordersInventory;
        }

        public DisplayAllOrdersResponse Display(DateTime OrderDate)
        {
            DisplayAllOrdersResponse Response = _ordersInventory.LoadOrder(OrderDate);

            


            return Response;


        }

        public OrderLookUpResponse OrderLookUp(DateTime OrderDate, int OrderNumber)
        {
            OrderLookUpResponse response = new OrderLookUpResponse();
            Order _order = _ordersInventory.LookUpOrder(OrderDate, OrderNumber);
            if (_order == null)
            {
                response.Success = false;
                response.Order = null;
                response.Message = "Order not found";
                return response;
            };


            response.Success = true;
            response.Message = "Order found";
            response.Order = (Order)_order;


            return response;

        }

        public EditResponse UpdateOrder(Order OldOrder, Order UpdatedOrder)
        {
            decimal _CostPerSquareFoot, _LaborCostPerSquareFoot, _TaxRate;
            EditResponse Response = new EditResponse();
            Response.OldOrder = OldOrder;

            DataValidation dataValidation = new DataValidation();
            Response dataValidationResponse = dataValidation.ValidateOrderData(UpdatedOrder, out _CostPerSquareFoot, out _LaborCostPerSquareFoot, out _TaxRate);

            if (!dataValidationResponse.Success)
            {
                Response.Success = false;
                Response.Message = dataValidationResponse.Message;
                Response.UpdatedOrder = UpdatedOrder;
                return Response;
            }

                     
                                 
            if ((OldOrder.Area == UpdatedOrder.Area) && (OldOrder.ProductType == UpdatedOrder.ProductType) && (OldOrder.State == UpdatedOrder.State))
            {

                Response.UpdatedOrder = OldOrder;
                Response.UpdatedOrder.CustomerName = UpdatedOrder.CustomerName;
                Response.Success = true;
                Response.Message = "Customer Name change only";
                return Response;
            }

            UpdatedOrder.TaxRate = _TaxRate;

            if (OldOrder.ProductType == UpdatedOrder.ProductType)
            {
                UpdatedOrder.CostPerSquareFoot = OldOrder.CostPerSquareFoot;
                UpdatedOrder.LaborCostPerSquareFoot = OldOrder.LaborCostPerSquareFoot;
            }
            else
            {
                UpdatedOrder.CostPerSquareFoot = _CostPerSquareFoot;
                UpdatedOrder.LaborCostPerSquareFoot = _LaborCostPerSquareFoot;
            }


            Calculator calculator = new Calculator();
            UpdatedOrder.MaterialCost = calculator.CalculateMaterialCost(UpdatedOrder.Area, UpdatedOrder.CostPerSquareFoot);
            UpdatedOrder.LaborCost = calculator.CalculateLaborCost(UpdatedOrder.Area, UpdatedOrder.LaborCostPerSquareFoot);
            UpdatedOrder.Tax = calculator.CalculateTax(UpdatedOrder.TaxRate, UpdatedOrder.MaterialCost, UpdatedOrder.LaborCost);
            UpdatedOrder.Total = calculator.CalculateTotalCost(UpdatedOrder.MaterialCost, UpdatedOrder.LaborCost, UpdatedOrder.Tax);

            
            Response.UpdatedOrder = UpdatedOrder;
            Response.UpdatedOrder.OrderDate = OldOrder.OrderDate;
            Response.UpdatedOrder.OrderNumber = OldOrder.OrderNumber;

            Response.Success = true;
            Response.Message = "Successfully updated the order";

            return Response;
        }

        public AddOrderResponse AddNewOrder(Order NewOrder)
        {
            AddOrderResponse Response = new AddOrderResponse();
            decimal _CostPerSquareFoot, _LaborCostPerSquareFoot, _TaxRate;
            Response.Order = NewOrder;

            DataValidation dataValidation = new DataValidation();
            Response dataValidationResponse = dataValidation.ValidateOrderData(NewOrder, out _CostPerSquareFoot, out _LaborCostPerSquareFoot, out _TaxRate);

            if (!dataValidationResponse.Success)
            {
                Response.Success = false;
                Response.Message = dataValidationResponse.Message;
                return Response;
            }


            NewOrder.CostPerSquareFoot = _CostPerSquareFoot;
            NewOrder.LaborCostPerSquareFoot = _LaborCostPerSquareFoot;

            NewOrder.TaxRate = _TaxRate;


            Calculator calculator = new Calculator();
            NewOrder.MaterialCost = calculator.CalculateMaterialCost(NewOrder.Area, NewOrder.CostPerSquareFoot);
            NewOrder.LaborCost = calculator.CalculateLaborCost(NewOrder.Area, NewOrder.LaborCostPerSquareFoot);
            NewOrder.Tax = calculator.CalculateTax(NewOrder.TaxRate, NewOrder.MaterialCost, NewOrder.LaborCost);
            NewOrder.Total = calculator.CalculateTotalCost(NewOrder.MaterialCost, NewOrder.LaborCost, NewOrder.Tax);

            Response.Order = NewOrder;
            Response.Success = true;
            Response.Message = "New Order successfully updated";

            return Response;
        }

        public SaveOrderResponse SaveOrder(Order OrderToBeSaved)
        {
            SaveOrderResponse response = _ordersInventory.SaveOrder(OrderToBeSaved);

            return response;
        }

        public Response DeleteOrder(Order OrderToBeDeleted)
        {
            Response response = _ordersInventory.DeleteOrder(OrderToBeDeleted);

            return response;
        }

    }
}
        