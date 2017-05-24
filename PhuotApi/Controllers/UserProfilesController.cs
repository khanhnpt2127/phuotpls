using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PhuotApi.Models;

namespace PhuotApi.Controllers
{
    public class UserProfilesController : ApiController
    {
        private PhuotApiContext db = new PhuotApiContext();

        
        // GET: api/UserProfiles/5
        [Route("api/user/{id}")]
        public async Task<IHttpActionResult> GetUserProfilebyId(int id)
        {
            UserProfile userProfile = await db.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        // PUT: api/UserProfiles/5
        [HttpPut]
        [Route("api/user/{id}")]
        public async Task<IHttpActionResult> UpdateUserProfile(int id, UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            db.Entry(userProfile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserProfiles
        [HttpPost]
        [Route("api/user",Name = "PostUser")]
        public async Task<IHttpActionResult> CreateNewUser(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProfiles.Add(userProfile);
            await db.SaveChangesAsync();

            return CreatedAtRoute("PostUser", new { id = userProfile.Id }, userProfile);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool UserProfileExists(int id)
        {
            return db.UserProfiles.Count(e => e.Id == id) > 0;
        }
    }
}