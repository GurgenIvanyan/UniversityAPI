using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Web.Application.DTOs;
using Web.Application.Interfaces;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetAll()
        {
            return Ok(await _courseRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetById(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpGet("page")]
        public async Task<ActionResult<List<CourseDto>>> GetByPage(int page = 1, int pageSize = 10)
        {
            var courses = await _courseRepository.GetByPageAsync(page, pageSize);
            return Ok(courses);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateCourseDto dto)
        {
            await _courseRepository.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CreateCourseDto dto)
        { 
            await _courseRepository.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _courseRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
