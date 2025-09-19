using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.DTOs
{
    public class CreateAuthorDto
    {
        public string UserName { get; set; } = string.Empty;

        public int CourseId { get; set; }
    }
}
