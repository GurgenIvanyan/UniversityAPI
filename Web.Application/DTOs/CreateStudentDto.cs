using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DTOs
{
    public class CreateStudentDto
    {
        public readonly int Id;

        public string UserName { get; set; } = string.Empty;

        public List<int> CourseIds { get; set; } = new List<int>();
    }
}
