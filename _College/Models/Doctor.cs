using System.ComponentModel.DataAnnotations;

namespace _College.Models
{
    public class Doctor : BaseEntity
    {
        public Doctor()
        {
            DoctorCourse = new List<DoctorCourse>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public ICollection<DoctorCourse> DoctorCourse { get; set; }
    }
}
