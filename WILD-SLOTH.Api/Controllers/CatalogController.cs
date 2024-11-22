using Microsoft.AspNetCore.Mvc;
using WILD.SLOTH.Domain.catalog;
using WILD.SLOTH.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WILD.SLOTH.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {

        // private readonly StoreContext _db;

        // public CatalogController(StoreContext db)
        // {
        //     _db = db;
        // }

        [HttpGet]
        public IActionResult GetItems()
        {
            //return Ok("Hello World--");
            var items = new List<Item>()
            {
                new Item("Shirt", "Ohio State Shirt", "Nike", 39.99m),
                new Item("Shorts", "Ohio State shorts", "Nike", 49.99m)
            };
            return Ok(items);
            //return Ok(_db.Items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = new Item("Shirt", "Ohio State Shirt", "Nike", 59.99m);
            item.Id = id;

            // var item = _db.Items.Find(id);
            // if (item == null)
            // {
            //     return NotFound();
            // }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem(Item item)
        {
            // return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
            return Created("/catalog/42", item);
            // _db.Items.Add(item);
            // _db.SaveChanges();
            // return Created($"/catalog/{item.Id}", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            // var item = _db.Items.Find(id);
            // if (item == null)
            // {
            //     return NotFound();
            // }
            // item.AddRating(rating);
            // _db.SaveChanges();

            // return Ok(item);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            // if (id != item.Id)
            // {
            //     return BadRequest();
            // }

            // if (_db.Items.Find(id) == null)
            // {
            //     return NotFound();
            // }

            // _db.Entry(item).State = EntityState.Modified;
            // _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize("delete:catalog")]
        public IActionResult Delete(int id)
        {
            // var item = _db.Items.Find(id);
            // if (item == null)
            // {
            //     return NotFound();
            // }

            // _db.Items.Remove(item);
            // _db.SaveChanges();

            return Ok();
        }

    }

}

