using ClientService.Models;
using ClientService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientService.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IRepository<User> _repoUser;
        public int Id = 0;
        public UserController(IRepository<User> repoUser)
        {
            this._repoUser = repoUser;
        }

        //Get All Values
        [HttpGet("GetUSer")]
        public IEnumerable<User> GetUserDetails()
        {
            var userData = _repoUser.GetAll();
            return userData;
        }


        
        //Get specific Values
        [HttpGet("GetSpecificUSer/{id:int}")]
        public IEnumerable<User> GetSpecificDetail(int id)
        {
            var userData = _repoUser.GetAll().Where(x=>x.Id == id);
            return userData;
        }

        // POST api/values
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] User oUser)
        {
            
            try
            {
                oUser.Password =  UtilityRepository.Encrypt(oUser.Password, "sblw-3hn8-sqoy19");
                int res = _repoUser.Insert(oUser);
                if (res != 0)
                {
                    return Ok(res);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // PUT api/values
        [HttpPut]
        [Route("UpdateUser/{id:int}")]
        public IActionResult UpdateUser([FromBody] User oUser,int id)
        {
            try
            {
                oUser.Password = UtilityRepository.Encrypt(oUser.Password, "sblw-3hn8-sqoy19");
                int res = _repoUser.Update(oUser);
                if (res != 0)
                {
                    return Ok(res);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // PUT api/values
        [HttpDelete]
        [Route("DeleteUser/{id:int}")]
        public IActionResult DeleteUser(long id)
        {
            try
            {
                User oUser = _repoUser.GetAll().Where(x => x.Id == id).FirstOrDefault();
                int res = _repoUser.Delete(oUser);
                if (res != 0)
                {
                    return Ok(res);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
