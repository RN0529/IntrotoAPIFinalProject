using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeCardAPI.Models;


namespace AnimeCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly AnimeAPIContext _context;
        public CardController(AnimeAPIContext context)
        {
            _context = context;
        }
        // GET: api/Card
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCard()
        {
            //return await _context.Card.ToListAsync();
            return Ok(await _context.Card.ToListAsync());
        }
        // GET: api/Card/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> Card(int id)
        {
            var Card = await _context.Card.FindAsync(id);

            if (Card == null)
            {
                var responseObj = new Response(400, "Bad Request: Data retrieved unsuccessfuly data not found");
                return NotFound(responseObj);
            }

            var responseObj2 = new Response(200, "Good Request: Data retrieved Successfuly", Card);
            return Ok(responseObj2);
        }

        // PUT: api/Card/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card Card)
        {
            if (id != Card.BoxID)
            {
                var responseObj = new Response(400, "Data retrieved unsuccessfuly please enter correct ID");
                return BadRequest(responseObj);
            }

            _context.Entry(Card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    var responseObj2 = new Response(400, "Bad request: data was not found please enter an existing ID");
                    return NotFound(responseObj2);
                }
                else
                {
                    throw;
                }
            }
            var responseObj3 = new Response(200, "Good request: Data will be updated");
            return Ok(responseObj3);
        }


        // POST: api/Card
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card Card)
        {
            _context.Card.Add(Card);
            await _context.SaveChangesAsync();
            var responseObj = new Response(200, "Good Response: Data will be added", Card);
            return CreatedAtAction("GetCard", new { id = Card.CardID }, responseObj);
        }

        // DELETE: api/Card/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var Card = await _context.Card.FindAsync(id);
            if (Card == null)
            {
                var responseObj = new Response(400, "Bad Response: Data not found please enter an existing id");
                return NotFound(responseObj);
            }

            _context.Card.Remove(Card);
            await _context.SaveChangesAsync();
            var responseObj2 = new Response(200, "Good Response: Data will be deleted");
            return Ok(responseObj2);
        }

        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.BoxID == id);
        }



    }
}
