﻿using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using PhuotApi.Models;
using PhuotApi.Models.DTOModels;
using static System.String;

namespace PhuotApi.Controllers
{
    public class UserAccountsController : ApiController
    {
        PhuotApiContext DbContext = new PhuotApiContext();

        [Route("api/account/{id}")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateUserAccount(Guid id, [FromBody] UserInfo fu)
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
                SaltPassword = saltPassword,
                HashPassword = PasswordCalculating.EncryptPassword(fu.password, saltPassword),
                Id = id,
                UserName = fu.username,
                StatusId = fu.statusId = 2
            });
            //DbContext.UserAccounts.Add(userAccount);
            await DbContext.SaveChangesAsync();


            //For test, changing later
            return StatusCode(HttpStatusCode.Created);
        }

        //Change password via username (inside app)
        [Route("api/account/{username}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdatePassword(string username, [FromBody] UserInfo fu)
        {
            var finduserName = DbContext.UserAccounts.FirstOrDefault(x => x.UserName == username);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (finduserName == null)
            {
                return BadRequest();
            }
            string hashpw = PasswordCalculating.EncryptPassword(fu.oldPassword, finduserName.SaltPassword);
            if (!String.Equals(hashpw, finduserName.HashPassword))
            {
                return BadRequest();
            }
            finduserName.SaltPassword = PasswordCalculating.GeneratedSaltPassword();
            finduserName.HashPassword = PasswordCalculating.EncryptPassword(fu.newPassword, finduserName.SaltPassword);

            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


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
