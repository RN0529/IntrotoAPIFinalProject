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
            return await _context.Card.ToListAsync();
        }
        // GET: api/Card/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> Card(int id)
        {
            var Card = await _context.Card.FindAsync(id);

            if (Card == null)
            {
                return NotFound();
            }

            return Card;
        }

        // PUT: api/Card/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Card Card)
        {
            if (id != Card.BoxID)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Card
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card Card)
        {
            _context.Card.Add(Card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = Card.CardID }, Card);
        }

        // DELETE: api/Card/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var Card = await _context.Card.FindAsync(id);
            if (Card == null)
            {
                return NotFound();
            }

            _context.Card.Remove(Card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.BoxID == id);
        }



    }
}
