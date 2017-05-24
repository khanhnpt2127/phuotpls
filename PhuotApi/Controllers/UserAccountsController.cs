using System;
using System.Linq;
using System.Net;
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
        public async Task<IHttpActionResult> CreateUserAccount(int id, [FromBody]UserInfo fu)
        {
            //if (id != userAccount.Id)
            //{
            //    return BadRequest();
            //}
            byte[] saltPassword = PasswordCalculating.GeneratedSaltPassword();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            DbContext.UserAccounts.Add(new UserAccount()
            {
                Email = fu.email,
                SaltPassword = Convert.ToBase64String(saltPassword),
                HashPassword = PasswordCalculating.EncryptPassword(fu.password, saltPassword),
                Id = id,
                UserName = fu.username,
                StatusId = fu.statusId
            });
            //DbContext.UserAccounts.Add(userAccount);
            await DbContext.SaveChangesAsync();

            //For test, changing later
            return StatusCode(HttpStatusCode.NoContent);
        }

        //[Route("api/account/{username}")]
        //[HttpPut]
        //public IHttpActionResult UpdatePassword(string username, string oldPassword)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //}
        public bool CheckPassword(string username, string hashpassword)
        {
            if (DbContext.UserAccounts.FirstOrDefault(x => x.UserName == username && x.HashPassword == hashpassword) != null)
            {
                return true;
            }
            return false;
        }
    }
}
