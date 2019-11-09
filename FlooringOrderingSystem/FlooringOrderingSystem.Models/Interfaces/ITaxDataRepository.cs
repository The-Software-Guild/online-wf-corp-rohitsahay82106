using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Interfaces
{
    public interface ITaxDataRepository
    {
        StateTaxLookUpResponse TaxRateLookup(string StateAbbreviation);
    }
}
