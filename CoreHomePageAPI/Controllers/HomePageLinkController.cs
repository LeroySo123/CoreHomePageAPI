using CoreHomePageAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreHomePageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageLinkController : ControllerBase
    {
        private readonly DemoContext _demoContext;

        public HomePageLinkController(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        // GET: api/<HomePageLinkController>
        [HttpGet]
        public ActionResult<IEnumerable<LinkList>> Get()
        {
            return _demoContext.LinkLists;
        }

        // GET api/<HomePageLinkController>/5
        [HttpGet("{id}")]
        public ActionResult<LinkList> Get(int id)
        {
            var result = _demoContext.LinkLists.Find(id);
            if (result == null)
            {
                return NotFound("No Item");
            }


            return result;
        }

        // POST api/<HomePageLinkController>
        [HttpPost]
        public ActionResult<LinkList> Post([FromBody] LinkList value)
        {
            _demoContext.LinkLists.Add(value);
            _demoContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = value.LinkId }, value);
        }

        // PUT api/<HomePageLinkController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LinkList value)
        {
            if (id != value.LinkId)
            {
                return BadRequest();
            }

            _demoContext.Entry(value).State = EntityState.Modified;

            try
            {
                _demoContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (!_demoContext.LinkLists.Any(e => e.LinkId == id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return NoContent();
        }

        // DELETE api/<HomePageLinkController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete = _demoContext.LinkLists.Find(id);
            if (delete == null)
            {
                return NotFound();
            }
            _demoContext.LinkLists.Remove(delete);
            _demoContext.SaveChanges();
            return NoContent();
        }
    }
}
