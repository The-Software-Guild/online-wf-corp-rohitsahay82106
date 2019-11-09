using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Responses
{
    public class StateTaxLookUpResponse: Response
    {
        public TaxData TaxData { get; set; }
    }
}
