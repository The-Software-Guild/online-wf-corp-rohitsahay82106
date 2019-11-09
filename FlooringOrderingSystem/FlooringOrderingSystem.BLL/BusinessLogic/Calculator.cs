using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL.BusinessLogic
{
    public class Calculator
    { 
        public decimal CalculateTax(decimal TaxRate, decimal MaterialCost, decimal LaborCost)
        {
            decimal TotalTax = Math.Round((MaterialCost + LaborCost) * (TaxRate / 100),2);
            
            return TotalTax;
        }

        public decimal CalculateMaterialCost(decimal Area, decimal CostPerSquareFoot)
        {
            decimal TotalMaterialCost = Math.Round(Area * CostPerSquareFoot,2);
            return TotalMaterialCost;
        }

        public decimal CalculateLaborCost(decimal Area, decimal LaborCostPerSquareFoot)
        {
            decimal TotalLaborCost = Math.Round(Area * LaborCostPerSquareFoot,2);
            return TotalLaborCost;
        }

        public decimal CalculateTotalCost(decimal TotalMaterialCost,decimal TotalLaborCost, decimal TotalTax)
        {
            decimal TotalCost = Math.Round(TotalMaterialCost + TotalLaborCost + TotalTax,2);
            return TotalCost;
        }
    }
}
