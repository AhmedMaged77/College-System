namespace _College.DTOs
{
    public class GetAllStudentsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public float GPA { get; set; }
        public string BatchName { get; set; }
        public string BatchYear { get; set; }
    }
}
