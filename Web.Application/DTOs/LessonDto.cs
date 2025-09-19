namespace Web.Application.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LessonText { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string? CourseTitle { get; set; }
    }
}
