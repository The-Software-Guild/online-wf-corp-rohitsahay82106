using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class SalesAPIController : ApiController
    {
        [Route("api/Sales/Search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string userName, DateTime? fromDate, DateTime? toDate)
        {
            SalesSearchParameters parameters = new SalesSearchParameters()
            {
                UserName = userName,
                FromDate = fromDate,
                ToDate = toDate
            };

            var repo = SalesRepositoryFactory.GetDataRepository();

            try
            {
                var result = repo.SalesSearchResult(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
