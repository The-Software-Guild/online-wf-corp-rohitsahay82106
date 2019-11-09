using FlooringOrderingSystem.Models.Interfaces;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL
{
    public class StateTaxManager
    {
        private ITaxDataRepository _iTaxDataRepository;
        public StateTaxManager(ITaxDataRepository taxDataRepository)
        {
            _iTaxDataRepository = taxDataRepository;
        }
        public StateTaxLookUpResponse TaxRateLookup(string StateAbbreviation)
        {
            StateTaxLookUpResponse stateTaxLookUpResponse = _iTaxDataRepository.TaxRateLookup(StateAbbreviation);
            return stateTaxLookUpResponse;

        }
    }
}
