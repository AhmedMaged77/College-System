using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace _College.DTOs
{
    public class GetAllCoursesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Hours { get; set; }
        public String BatchName { get; set; }
    }
}
