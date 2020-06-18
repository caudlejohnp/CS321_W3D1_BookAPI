using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace CS321_W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService myAuthorService)
        {
            _authorService = myAuthorService;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll());
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _authorService.Get(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromBody] Author newAuthor)
        {
            var author = _authorService.Add(newAuthor);
            if (author == null) return BadRequest();
            return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author updateAuthor)
        {

            var author = _authorService.Update(updateAuthor);
            if (author == null) return BadRequest();
            return Ok(author);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var book = _bookService.Get(id);
            //_bookService.Delete(book);
            //return NoContent();
            var author = _authorService.Get(id);
            _authorService.Delete(author);
            return NoContent();
        }
    }
}
