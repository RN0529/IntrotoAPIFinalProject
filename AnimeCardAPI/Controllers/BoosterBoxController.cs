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
    public class BoosterBoxController : ControllerBase
    {
        private readonly AnimeAPIContext _context;
        public BoosterBoxController(AnimeAPIContext context)
        {
            _context = context;
        }

        // GET: api/BoosterBox
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoosterBox>>> GetBoosterBoxs()
        {
            return await _context.BoosterBox.ToListAsync();
        }


        // GET: api/BoosterBox/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoosterBox>> GetBoosterBox(int id)
        {
            var BoosterBox = await _context.BoosterBox.FindAsync(id);

            if (BoosterBox == null)
            {
                return NotFound();
            }

            return BoosterBox;
        }

        // PUT: api/BoosterBox/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, BoosterBox BoosterBox)
        {
            if (id != BoosterBox.BoxID)
            {
                return BadRequest();
            }

            _context.Entry(BoosterBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoosterBoxExists(id))
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


        // POST: api/BoosterBox
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BoosterBox>> PostBoosterBox(BoosterBox BoosterBox)
        {
            _context.BoosterBox.Add(BoosterBox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoosterBox", new { id = BoosterBox.BoxID }, BoosterBox);
        }

        // DELETE: api/BoosterBox/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoosterBox(int id)
        {
            var BoosterBox = await _context.BoosterBox.FindAsync(id);
            if (BoosterBox == null)
            {
                return NotFound();
            }

            _context.BoosterBox.Remove(BoosterBox);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoosterBoxExists(int id)
        {
            return _context.BoosterBox.Any(e => e.BoxID == id);
        }



    }


}
