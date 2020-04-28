using DVD.Data.Factories;
using DVD.Models.Tables;
using DVD_Catalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVD_Catalogue.Controllers
{
    [EnableCors(origins: "*",headers:"*",methods:"*")]
    public class DVDController : ApiController
    {
        [Route("api/dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DVDS()
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var result = repo.GetAllDvds();
            return Ok(result);
        }

        [Route("api/dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByDirector(string director)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var result = repo.GetDvdByDirector(director);
            return Ok(result);
        }

        [Route("api/dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByTitle(string title)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var result = repo.GetDvdByTitle(title);
            return Ok(result);
        }

        [Route("api/dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByReleaseYear(short releaseYear)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var result = repo.GetDvdByYear(releaseYear);
            return Ok(result);
        }

        [Route("api/dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByRating(string rating)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var result = repo.GetDvdByRating(rating);
            return Ok(result);
        }

        [Route("api/dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsById(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var result = repo.GetDvdById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [Route("api/dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddNewDVD(JSONDvdModel dvd)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            repo.AddNewDVD(dvd);

            if (dvd!=null&& dvd.dvdId > 0)
            {
                return Ok(dvd);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [Route("api/dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateDvd(int id,JSONDvdModel Dvd)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            if (id != Dvd.dvdId)
            {
                return BadRequest();
            }

            repo.UpdateDVD(Dvd);

            if (Dvd != null && Dvd.dvdId == id)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [Route("api/dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteDvd(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            repo.DeleteDVD(id);
            
            return Ok();
            

        }

    }
}
