using DVDLibrary.BLL;
using DVDLibrary.Models;
using DVDLibrary.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DVDController : ApiController
    {
        DVDManager manager = DVDManagerFactory.Create();

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(manager.GetAll().DVDs);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            DVDResponse found = manager.GetById(id);
            var dvdById = new DVDView(found.DVD);

            if (found.DVD == null)
            {
                return NotFound();
            }

            return Ok(dvdById);
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            ListOfDVDResponse found = manager.GetByTitle(title);

            if (found.DVDs.Count == 0)
            {
                return NotFound();
            }

            return Ok(found.DVDs);
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string directorName)
        {
            ListOfDVDResponse found = manager.GetByDirector(directorName);

            if (found.DVDs.Count == 0)
            {
                return NotFound();
            }

            return Ok(found.DVDs);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            ListOfDVDResponse found = manager.GetByRating(rating);

            if (found.DVDs.Count == 0)
            {
                return NotFound();
            }

            return Ok(found.DVDs);
        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByReleaseYear(int year)
        {
            ListOfDVDResponse found = manager.GetByReleaseYear(year);

            if (found.DVDs.Count == 0)
            {
                return NotFound();
            }

            return Ok(found.DVDs);
        }

        [Route("dvd")]
        [HttpPost]
        public IHttpActionResult NewDVD(DVDView dvd)
        {
            DVDResponse create = manager.NewDVD(dvd.title, dvd.director, dvd.rating, dvd.realeaseYear, dvd.notes);

            if (create.DVDView == null)
            {
                return NotFound();
            }

            return Ok(create.DVDView);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult EditDVD(DVDView dvd)
        {
            DVDResponse update = manager.EditDVD(dvd, dvd.director, dvd.notes, dvd.rating, dvd.realeaseYear, dvd.title);

            if (update.DVDView == null)
            {
                return NotFound();
            }

            return Ok(update.DVDView);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void DeleteDVD(int id)
        {
            manager.DeleteDVD(id);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult showDVDDetails(DVDView dvd)
        {
            DVDResponse response = manager.EditDVD(dvd, dvd.director, dvd.notes, dvd.rating, dvd.realeaseYear, dvd.title);

            return Ok(response.DVDView);
        }
    }
}