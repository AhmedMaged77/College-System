namespace _College.DTOs
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public float GPA { get; set; }
        public int BatchId { get; set; }
    }
}
