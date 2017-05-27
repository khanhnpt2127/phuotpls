using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PhuotApi.Models;
using PhuotApi.Models.DTOModels;

namespace PhuotApi.Controllers
{
    public class PlacesController : ApiController
    {
        PhuotApiContext db = new PhuotApiContext();

        //Longtitude and Attitude ate taken from choosing place that existed before
        //or use GPS to get automatically
        [Route("api/place")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateTask([FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            db.Places.Add(place);

            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.Created);
        }

        [Route("api/place/{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateTask(int id, [FromBody] PlaceInfo place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var find = db.Places.FirstOrDefault(x => x.PlaceId == id);
            if (find == null)
            {
                return BadRequest("Update fail");
            }

            try
            {
                find.PlaceName = place.placename;
                find.TypeId = place.typeid;

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Bug
        [Route("api/place/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeletePlace(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var find = db.Places.FirstOrDefault(x => x.PlaceId == id);
            if (find == null || find.PlaceId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                db.Places.Remove(find);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
