using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace rubix.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName {get;set;}
        public string Avatar {get; set;}
    }
}