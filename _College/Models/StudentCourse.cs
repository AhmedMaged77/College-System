using System.ComponentModel.DataAnnotations.Schema;

namespace _College.Models
{
    public class StudentCourse
    {
        public int SudentId { get; set; }
        public Student student { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
        public int Exam_Duration { get; set; }
        public DateTime Exam_Date { get; set; }

    }
}
