using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Part3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_Part3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class itemsController : ControllerBase
    {
        //db

        private Part3Model db;

        public itemsController(Part3Model db)
        {
            this.db = db;
        }

        //GET: api/items
        [HttpGet]
        public IEnumerable<item> Get()
        {
            return db.items.OrderBy(a => a.item_id).ToList();
        }

        //GET: api/items/5
        [HttpGet("{id}")]

        public ActionResult Get(int id)
        {
            item item = db.items.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        //POST: api/items
        [HttpPost]
        public ActionResult Post([FromBody] item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.items.Add(item);
            db.SaveChanges();
            return CreatedAtAction("Post", item);
        }

        //PUT: api/items/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        //DELETE: api/items/5
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            item item = db.items.Find(id);

            if(item == null)
            {
                return NotFound();
            }

            db.items.Remove(item);
            db.SaveChanges();
            return Ok();
        }
        
    }
}