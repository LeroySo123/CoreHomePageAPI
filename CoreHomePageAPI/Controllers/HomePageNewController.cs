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
    public class HomePageNewController : ControllerBase
    {
        private readonly DemoContext _demoContext;

        public HomePageNewController(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        // GET: api/<HomePageNewController>
        [HttpGet]
        public ActionResult<IEnumerable<NewList>> Get()
        {

            return _demoContext.NewLists;
        }

        // GET api/<HomePageNewController>/5
        [HttpGet("{id}")]
        public ActionResult<NewList> Get(int id)
        {
            var result = _demoContext.NewLists.Find(id);
            if(result == null)
            {
                return NotFound("No Item");
            }


            return result;
        }

        // POST api/<HomePageNewController>
        [HttpPost]
        public ActionResult<NewList> Post([FromBody] NewList value)
        {
            _demoContext.NewLists.Add(value);
            _demoContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = value.NewId }, value);
        }

        // PUT api/<HomePageNewController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NewList value)
        {
            if(id != value.NewId)
            {
                return BadRequest();
            }

            _demoContext.Entry(value).State = EntityState.Modified;

            try
            {
                _demoContext.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(!_demoContext.NewLists.Any(e=> e.NewId == id))
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

        // DELETE api/<HomePageNewController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete = _demoContext.NewLists.Find(id);
            if(delete == null)
            {
                return NotFound();
            }
            _demoContext.NewLists.Remove(delete);
            _demoContext.SaveChanges();
            return NoContent();
        }
    }
}
