using System.ComponentModel.DataAnnotations;

namespace _College.Models
{
    public class Course : BaseEntity
    {
        public Course()
        {
            DoctorCourse = new List<DoctorCourse>();
        }
        public string Title { get; set; }
        public int Hours { get; set; }
        public int? Exam_Duration { get; set; }
        public DateTime? Exam_Date { get; set; }
        public int BatchId { get; set; }
        public Batch Batch { get; set; }
        public ICollection<DoctorCourse> DoctorCourse { get; set; }

    }
}
