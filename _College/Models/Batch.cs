using System.ComponentModel.DataAnnotations;

namespace _College.Models
{
    public class Batch : BaseEntity
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }

    }
}
