using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rubix.Models;

namespace rubix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AngularController : ControllerBase
    {

        ResourceContext _context;

        public AngularController(ResourceContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Resources>> Get()
        {
            return _context.Resources;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/angular
        [HttpPost]
        public void Post([FromBody] Resources resources)
        {
            _context.Resources.Add(resources);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/angular/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Resources deleteResource = _context.Resources.Find(id);

            _context.Resources.Remove(deleteResource);
            _context.SaveChanges();
        }
    }
}
