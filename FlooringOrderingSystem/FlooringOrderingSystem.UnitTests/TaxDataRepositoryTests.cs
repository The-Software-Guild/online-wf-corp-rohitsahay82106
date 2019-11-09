using FlooringOrderingSystem.BLL;
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
    public class TaxDataRepositoryTests
    {
        [TestCase("OH", 6.25, "Ohio", true)]
        [TestCase("FL", 7.50, "Kentucky", false)]
        [TestCase("PA", 6.75, "Pennsylvania",true)]
        [TestCase("in", 6.00, "Indiana", false)]
        [TestCase("IN", 6.00, "Indiana", true)]
        [TestCase("Ohio", 6.25, "Ohio", false)]
        public void StateTaxLookupTest(string StateAbbreviation, decimal TaxRate, string StateName,bool ExpectedResult)
        {

            StateTaxManager _taxDataRepository = StateTaxManagerFactory.Create();

            StateTaxLookUpResponse stateTaxLookUpResponse = _taxDataRepository.TaxRateLookup(StateAbbreviation);
            Assert.AreEqual(ExpectedResult, stateTaxLookUpResponse.Success);
            if (stateTaxLookUpResponse.Success)
            {
                Assert.AreEqual(TaxRate, stateTaxLookUpResponse.TaxData.TaxRate);
                Assert.AreEqual(StateName, stateTaxLookUpResponse.TaxData.StateName);
            }


        }
    }
}
