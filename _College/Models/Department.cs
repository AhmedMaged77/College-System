using System.ComponentModel.DataAnnotations;

namespace _College.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

    }
}
