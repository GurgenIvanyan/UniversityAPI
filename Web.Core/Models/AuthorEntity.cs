using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Core.Models;

public class AuthorEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public int CourseId { get; set; }
    public CourseEntity Course { get; set; }
}
