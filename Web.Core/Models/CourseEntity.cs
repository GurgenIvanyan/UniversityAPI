using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Core.Models
{
    public class CourseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<LessonEntity> Lessons { get; set; } 
        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; } = null!;
        public ICollection<StudentEntity>? Students { get; set; } = new List<StudentEntity>(); 
        
    

}
}
