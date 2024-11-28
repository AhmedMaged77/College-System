namespace _College.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int? Exam_Duration { get; set; }
        public DateTime? Exam_Date { get; set; }

    }
}
