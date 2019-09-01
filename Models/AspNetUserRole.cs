using System.ComponentModel.DataAnnotations;
namespace rubix.Models
{
    public class AspNetUserRole
    {                
        [Key]
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}