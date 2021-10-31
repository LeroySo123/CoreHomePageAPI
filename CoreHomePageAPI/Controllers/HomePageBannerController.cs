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
    public class HomePageBannerController : ControllerBase
    {
        private readonly DemoContext _demoContext;

        public HomePageBannerController(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        // GET: api/<HomePageBannerController>
        [HttpGet]
        public ActionResult<IEnumerable<BannerList>> Get()
        {
            return _demoContext.BannerLists;
        }

        // GET api/<HomePageBannerController>/5
        [HttpGet("{id}")]
        public ActionResult<BannerList> Get(int id)
        {
            var result = _demoContext.BannerLists.Find(id);
            if (result == null)
            {
                return NotFound("No Item");
            }


            return result;
        }

        // POST api/<HomePageBannerController>
        [HttpPost]
        public ActionResult<BannerList> Post([FromBody] BannerList value)
        {
            _demoContext.BannerLists.Add(value);
            _demoContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = value.BannerId }, value);
        }

        // PUT api/<HomePageBannerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BannerList value)
        {
            if (id != value.BannerId)
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
                if (!_demoContext.BannerLists.Any(e => e.BannerId == id))
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

        // DELETE api/<HomePageBannerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete = _demoContext.BannerLists.Find(id);
            if (delete == null)
            {
                return NotFound();
            }
            _demoContext.BannerLists.Remove(delete);
            _demoContext.SaveChanges();
            return NoContent();
        }
    }
}
