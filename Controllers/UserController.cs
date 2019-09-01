using System.Net;
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
    public class UserController : ControllerBase
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAspNetUsers")]
        public ActionResult<IEnumerable<AspNetUser>> GetAspNetUsers()
        {
            return _context.AspNetUsers;
        }  

        [HttpGet]
        [Route("getAspNetRoles")]
        public ActionResult<IEnumerable<AspNetRole>> GetAspNetRoles()
        {
            return _context.AspNetRoles;
        }            

        [HttpGet]
        [Route("getAspNetUserRoles")]
        public ActionResult<IEnumerable<AspNetUserRole>> GetAspNetUserRoles()
        {
            return _context.AspNetUserRoles;
        }   

        [HttpGet]
        [Route("getFullUserProfile")]      
        public IActionResult GetFullUserProfile(){
            var userProfile = (from aspnetusers in _context.AspNetUsers
                                join aspnetuserroles in _context.AspNetUserRoles on aspnetusers.id  equals aspnetuserroles.UserId
                                join aspnetroles in _context.AspNetRoles on aspnetuserroles.RoleId equals aspnetroles.id
                                select new {
                                    UserName = aspnetusers.UserName,
                                    Email = aspnetusers.Email,
                                    Role = aspnetroles.NormalizedName,
                                    FullName = aspnetusers.FullName,
                                    PhoneNumber = aspnetusers.PhoneNumber,
                                    Avatar = aspnetusers.Avatar
                                }).ToList();
            return Ok(userProfile);
        }
    }

}