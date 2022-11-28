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
            var responseObj = new Response(200, "Good Request: Data retrieved successfuly", _context.BoosterBox.ToListAsync());
            return Ok(responseObj);
        }


        // GET: api/BoosterBox/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoosterBox>> GetBoosterBox(int id)
        {
            var BoosterBox = await _context.BoosterBox.FindAsync(id);
            if (BoosterBox == null)
            {
                var responseObj = new Response(400,"Bad Request: Data retrieved unsuccessfuly data not found");
                return NotFound(responseObj);
            }
            var responseObj2 = new Response(200, "Good Request: Data retrieved Successfuly", BoosterBox);
            return Ok(responseObj2);
        }

        // PUT: api/BoosterBox/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoosterBox(int id, BoosterBox BoosterBox)
        {

            if (id != BoosterBox.BoxID)
            {
                var responseObj = new Response(400, "Data retrieved unsuccessfuly please enter correct ID");
                return BadRequest(responseObj);
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


        // POST: api/BoosterBox
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BoosterBox>> PostBoosterBox(BoosterBox BoosterBox)
        {
            
            _context.BoosterBox.Add(BoosterBox);
            await _context.SaveChangesAsync();

            var responseObj = new Response(200, "Good Response: Data will be added", BoosterBox);
            return CreatedAtAction("GetBoosterBox", new { id = BoosterBox.BoxID }, responseObj);
        }

        // DELETE: api/BoosterBox/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoosterBox(int id)
        {
            var BoosterBox = await _context.BoosterBox.FindAsync(id);
            if (BoosterBox == null)
            {
                var responseObj = new Response(400, "Bad Response: Data not found please enter an existing id");
                return NotFound(responseObj);
            }

            _context.BoosterBox.Remove(BoosterBox);
            await _context.SaveChangesAsync();
            var responseObj2 = new Response(200, "Good Response: Data will be deleted");
            return Ok(responseObj2);
        }

        private bool BoosterBoxExists(int id)
        {
            return _context.BoosterBox.Any(e => e.BoxID == id);
        }



    }


}
