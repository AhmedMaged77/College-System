using System.ComponentModel.DataAnnotations;

namespace _College.Models
{
    public class Admin 
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
