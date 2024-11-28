using System.ComponentModel.DataAnnotations;

namespace _College.Models
{
    public class Course : BaseEntity
    {
        public Course()
        {
            StudentCourse = new List<StudentCourse>();
            DoctorCourse = new List<DoctorCourse>();
        }
        public string Title { get; set; }
        public int Hours { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
        public ICollection<DoctorCourse> DoctorCourse { get; set; }

    }
}
