namespace _College.DTOs;

public class CreateExamDto
{
    public int BatchId { get; set; }
    public int CourseId { get; set; }
    public int Exam_Duration { get; set; }
    public DateTime Exam_Date { get; set; }
}
