using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Web.Application.DTOs;
using Web.Application.Interfaces;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAll()
        {
            return Ok(await _authorRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpGet("page")]
        public async Task<ActionResult<List<AuthorDto>>> GetByPage(int page = 1, int pageSize = 10)
        {
            var authors = await _authorRepository.GetByPageAsync(page, pageSize);
            return Ok(authors);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Add([FromBody] CreateAuthorDto dto)
        {
            await _authorRepository.AddAsync(dto);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CreateAuthorDto dto)
        {
            await _authorRepository.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _authorRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
