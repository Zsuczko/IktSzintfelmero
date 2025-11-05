using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Szakmak.Data;
using Szakmak.Models;

namespace Szakmak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrszagController : ControllerBase
    {
        private readonly SzakmakDbContext _context;

        public OrszagController(SzakmakDbContext context)
        {
            _context = context;
        }

        // GET: api/Orszag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orszag>>> GetOrszagok()
        {
            return await _context.Orszagok.ToListAsync();
        }

        // GET: api/Orszag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orszag>> GetOrszag(string id)
        {
            var orszag = await _context.Orszagok.FindAsync(id);

            if (orszag == null)
            {
                return NotFound();
            }

            return orszag;
        }

        // PUT: api/Orszag/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrszag(string id, Orszag orszag)
        {
            if (id != orszag.Id)
            {
                return BadRequest();
            }

            _context.Entry(orszag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrszagExists(id))
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

        // POST: api/Orszag
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orszag>> PostOrszag(Orszag orszag)
        {
            _context.Orszagok.Add(orszag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrszagExists(orszag.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrszag", new { id = orszag.Id }, orszag);
        }

        // DELETE: api/Orszag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrszag(string id)
        {
            var orszag = await _context.Orszagok.FindAsync(id);
            if (orszag == null)
            {
                return NotFound();
            }

            _context.Orszagok.Remove(orszag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrszagExists(string id)
        {
            return _context.Orszagok.Any(e => e.Id == id);
        }
    }
}
