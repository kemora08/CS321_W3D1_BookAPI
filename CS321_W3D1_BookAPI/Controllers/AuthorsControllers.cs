using CS321_W3D1_BookAPI.Models;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService AuthorService)
        {
            _authorService = AuthorService;
        }
        

        // GET api/authors
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll());
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _authorService.Get(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        // POST api/authors
        [HttpPost]
        public IActionResult Post([FromBody] Author myNewAuthor)
        {
            var author = _authorService.Add(myNewAuthor);
            if (author == null) return BadRequest();
            return CreatedAtAction("Get", new { Id = myNewAuthor.Id }, myNewAuthor);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author myUpdatedAuthor)
        {
            var Author = _authorService.Update(myUpdatedAuthor);
            if (Author == null) return NotFound();
            return Ok(Author);
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Author = _authorService.Get(id);
            if (Author == null) return NotFound();
            _authorService.Delete(Author);
            return NoContent();
        }
    }
}
