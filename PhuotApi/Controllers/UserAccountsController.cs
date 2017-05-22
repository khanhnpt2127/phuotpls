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
    public class UserAccountsController : ApiController
    {
        PhuotApiContext DbContext = new PhuotApiContext();

        [Route("api/account/{id:int}")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateUserAccount(int id, UserAccount userAccount)
        {
            if (id != userAccount.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            DbContext.UserAccounts.Add(userAccount);
            await DbContext.SaveChangesAsync();


            //For test, changing later
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Change password
        [Route("api/account/change-password/{id}")]
        public async Task<IHttpActionResult> ChangePassword(int id, string oldHashPassword, string oldSaltpassword, string newHashPassword, string newSaltPassword)
        {
            var find = await DbContext.UserAccounts.FindAsync(id);
            if (find == null)
            {
                return BadRequest();
            }

            //true if old hash password and old salt password are both correct in database
            if (oldHashPassword == find.HashPassword && oldSaltpassword == find.SaltPassword)
            {

            }
        }
    }
}
