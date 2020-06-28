using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.APIModels;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService myPublisherService)
        {
            _publisherService = myPublisherService;
        }

        // GET: api/<PublisherController>
        [HttpGet]
        public IActionResult Get()
        {
            var publisher = _publisherService.GetAll().ToApiModels();
            return Ok(publisher);
        }

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = _publisherService.Get(id).ToApiModel();
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromBody] PublisherModel newPublisher)
        {
            var publisher = _publisherService.Add(newPublisher.ToDomainModel());
            if (publisher == null) return BadRequest();
            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PublisherModel updatedPublisher)
        {

            var publisher = _publisherService.Update(updatedPublisher.ToDomainModel());
            if (publisher == null) return BadRequest();
            return Ok(publisher);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var book = _bookService.Get(id);
            //_bookService.Delete(book);
            //return NoContent();
            var publisher = _publisherService.Get(id);
            _publisherService.Delete(publisher);
            return NoContent();
        }
    }
}
