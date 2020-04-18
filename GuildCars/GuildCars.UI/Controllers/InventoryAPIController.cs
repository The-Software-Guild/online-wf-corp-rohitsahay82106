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
    public class InventoryAPIController : ApiController
    {
        [Route("api/Inventory/Search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(decimal? minPrice, decimal? maxPrice, short? minYear, short? maxYear, string quickSearch, string type)
        {
            VehicleSearchParameters parameters = new VehicleSearchParameters()
            {
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                MinYear = minYear,
                MaxYear = maxYear,
                QuickSearch = quickSearch
            };

            var repo = VehiclesRepositoryFactory.GetDataRepository();
            
            try
            {
                var result = repo.VehicleSearchResult(parameters,type);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [Route("api/Inventory/GetModel")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModel(int makeID)
        {
            
            var repo = VehiclesRepositoryFactory.GetDataRepository();

            try
            {
                var results = repo.GetVehicleModels(makeID);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}
