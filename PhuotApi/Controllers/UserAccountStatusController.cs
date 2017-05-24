using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PhuotApi.Models;

namespace PhuotApi.Controllers
{
    public class UserAccountStatusController : ApiController
    {
        private PhuotApiContext db = new PhuotApiContext();

        [Route("api/status", Name = "CreateAccountStatus")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateNewAccountStatus(UserAccountStatus status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            db.UserAccountStatuses.Add(status);

            await db.SaveChangesAsync();

            return CreatedAtRoute("CreateAccountStatus", new {id = status.StatusId}, status);
        }

        [Route("api/status/{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAccountStatus(int id, UserAccountStatus status)
        {
            if (id != status.StatusId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            db.Entry(status).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/status/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAccountStatus(int id)
        {
            var find = db.UserAccountStatuses.FirstOrDefault(x => x.StatusId == id);
            if (find == null)
            {
                return BadRequest();
            }
            db.UserAccountStatuses.Remove(find);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                
                throw;
            }
            return Ok("Delete user status succesfully");
        }
    }
}
