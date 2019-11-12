using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Interfaces;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data.ReferenceDataRepository
{
    public class TaxDataRepository:ITaxDataRepository
    {
        private readonly string path = @"..\..\..\FlooringOrderingSystem.Data\DataFiles\Taxes.txt";

        public StateTaxLookUpResponse TaxRateLookup(string StateAbbreviation)
        {
            bool TaxRateFound = false;
            StateTaxLookUpResponse Response = new StateTaxLookUpResponse();
            Response.Success = false;
            Response.Message = "Business is not allowed in this State";
            Response.TaxData = null;

            TaxData _taxData = new TaxData();
            
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                while (((line = reader.ReadLine()) != null) && (!TaxRateFound))
                {
                    string[] columns = line.Split(',');
                    if (StateAbbreviation == columns[0])
                    {
                        TaxRateFound = true;
                        _taxData.StateAbbreviation = columns[0];
                        _taxData.StateName = columns[1];
                        if (decimal.TryParse(columns[2], out decimal TaxRate))
                        {
                            _taxData.TaxRate = TaxRate;
                            Response.Success = true;
                            Response.Message = "Tax Rate for the State found";
                        }
                        else
                        {
                            Response.Success = false;
                            Response.Message = "Tax Rate for the State missing, contact IT";
                            _taxData.TaxRate = 99.99M;
                        }

                    }
                }

                Response.TaxData = _taxData;
            }

            

            return Response;
        }
    }
}
