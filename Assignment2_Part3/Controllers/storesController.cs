using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Part3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2_Part3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class storesController : ControllerBase
    {
        //db

        private Part3Model db;

        public storesController(Part3Model db)
        {
            this.db = db;
        }

        //GET: api/stores
        [HttpGet]
        public IEnumerable<store> Get()
        {
            return db.stores.OrderBy(a => a.book_id).ToList();
        }

        //GET: api/stores/5
        [HttpGet("{id}")]

        public ActionResult Get(int id)
        {
            store store = db.stores.Find(id);

            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        //POST: api/stores
        [HttpPost]
        public ActionResult Post([FromBody] store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.stores.Add(store);
            db.SaveChanges();
            return CreatedAtAction("Post", store);
        }

        //PUT: api/stores/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(store).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        //DELETE: api/stores/5
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            store store = db.stores.Find(id);

            if (store == null)
            {
                return NotFound();
            }

            db.stores.Remove(store);
            db.SaveChanges();
            return Ok();
        }
    }
}