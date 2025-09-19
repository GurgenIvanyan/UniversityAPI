using Web.Core.Models;

namespace Web.Application.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public List<int> CourseIds { get; set; } = new List<int>();


    }
}
