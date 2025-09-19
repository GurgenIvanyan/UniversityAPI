using Web.Core.Models;

namespace Web.Application.DTOs
{ 
    public class CourseDto
    {

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int AuthorId { get; set; }

    public List<int> StudentIds { get; set; } = new List<int>();
    
    }
}
