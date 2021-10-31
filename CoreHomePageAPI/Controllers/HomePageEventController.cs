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
    public class HomePageEventController : ControllerBase
    {
        private readonly DemoContext _demoContext;

        public HomePageEventController(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        // GET: api/<HomePageEventController>
        [HttpGet]
        public ActionResult<IEnumerable<EventList>> Get()
        {

            return _demoContext.EventLists;
        }

        // GET api/<HomePageEventController>/5
        [HttpGet("{id}")]
        public ActionResult<EventList> Get(int id)
        {
            var result = _demoContext.EventLists.Find(id);
            if (result == null)
            {
                return NotFound("No Item");
            }


            return result;
        }

        // POST api/<HomePageEventController>
        [HttpPost]
        public ActionResult<EventList> Post([FromBody] EventList value)
        {
            _demoContext.EventLists.Add(value);
            _demoContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = value.EventId }, value);
        }

        // PUT api/<HomePageEventController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EventList value)
        {
            if (id != value.EventId)
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
                if (!_demoContext.EventLists.Any(e => e.EventId == id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return Ok();
        }

        // DELETE api/<HomePageEventController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete = _demoContext.EventLists.Find(id);
            if (delete == null)
            {
                return NotFound();
            }
            _demoContext.EventLists.Remove(delete);
            _demoContext.SaveChanges();
            return Ok();
        }
    }
}
