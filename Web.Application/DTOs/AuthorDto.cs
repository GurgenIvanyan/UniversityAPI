namespace Web.Application.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public int CourseId { get; set; }
    }
}
