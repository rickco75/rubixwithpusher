using System.ComponentModel.DataAnnotations;
namespace rubix.Models
{
    public class AspNetRole
    {
        [Key]
        public string id { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}