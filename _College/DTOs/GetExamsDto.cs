namespace _College.DTOs
{
    public class GetExamsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Exam_Duration { get; set; }
        public DateTime? Exam_Date { get; set; }
        public int BatchId { get; set; }
    }
}
