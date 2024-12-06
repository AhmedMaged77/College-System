using _College.Models;

namespace _College.DTOs
{
    public class GetAllBatchsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public int NoOfStudents { get; set; }
    }
}
