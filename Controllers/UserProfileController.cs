using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using rubix.Models;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Security.Claims;

namespace rubix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserProfileController: ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile() 
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            //var userRole = await _userManager.FindByIdAsync(userId);

            return new 
            {
                user.FullName,
                user.Email,
                user.UserName,
                user.PhoneNumber,
                user.Avatar,                
            };
        }


        [HttpGet]
        [Authorize]
        [Route("getusers")]
         public ActionResult<IEnumerable<ApplicationUser>> Get()
        //public IActionResult<IAsyncEnumerable<ApplicationUser> Get()
        {
           // var users = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();
            //var users = _userManager.Users.Include(u => u.userRoles.Select(x => x.Role).toList());
            return _userManager.Users.ToList();
        }

        // DELETE api/userprofile/<string>
        //[Authorize]
        [HttpDelete("{id}")]
        //[Route("deleteuser")]
        
        //public async void Delete(string id)
        public async Task<ActionResult> DeleteUser(string id)
        {
            //string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);
            //Transaction.Commit();

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles="ADMIN")]
        [Route("ForAdmin")]
        public string GetForAdmin() {
            return "Web method for admin";
        }

        [HttpGet]
        [Authorize(Roles="CUSTOMER")]
        [Route("ForCustomer")]
        public string GetForCustomer() {
            return "Web method for Customer";
        }

        [HttpGet]
        [Authorize(Roles="ADMIN,CUSTOMER")]
        [Route("ForAdminOrCustomer")]
        public string GetForAdminOrCustomer() {
            return "Web method for admin or Customer";
        }                


    }
}