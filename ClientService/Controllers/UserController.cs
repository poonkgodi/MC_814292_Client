using ClientService.Models;
using ClientService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            try
            {
                var userData = _repoUser.GetAll();
                return userData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        ////Get All Values
        //[HttpGet("GetUSer")]
        //public async Task<IEnumerable<User>> GetUserDetails()
        //{
        //    try
        //    {
        //        var userData = await this._repoUser.GetAllasync();
        //        return userData;
        //    }
        //    catch(Exception ex)
        //    {
        //        return null;
        //    }
        //}



        //Get specific Values
        [HttpGet("GetSpecificUSer/{id:int}")]
        public IEnumerable<User> GetSpecificDetail(int id)
        {
            IEnumerable<User> userData = _repoUser.GetAll();
            userData = userData.Where(x => x.Id == id);
            return userData;
        }

        // POST api/values
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] User oUser)
        {
            try
            {
                oUser.Password = UtilityRepository.Encrypt(oUser.Password, "sblw-3hn8-sqoy19");
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
        public IActionResult UpdateUser([FromBody] User oUser, int id)
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
                var exitingUser = _repoUser.GetAll();
                var oUser = exitingUser.Where(x => x.Id == id).FirstOrDefault();
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
