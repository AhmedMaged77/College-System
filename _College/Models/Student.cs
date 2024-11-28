using System.ComponentModel.DataAnnotations;

namespace _College.Models
{
    public class Student : BaseEntity
    {
        public Student()
        {
            StudentCourses = new List<StudentCourse>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public int Year { get; set; }
        public float GPA { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
