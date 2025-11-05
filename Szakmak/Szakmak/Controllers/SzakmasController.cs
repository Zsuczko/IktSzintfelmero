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
    public class SzakmasController : ControllerBase
    {
        private readonly SzakmakDbContext _context;

        public SzakmasController(SzakmakDbContext context)
        {
            _context = context;
        }

        // GET: api/Szakmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Szakma>>> GetSzakmak()
        {
            return await _context.Szakmak.ToListAsync();
        }

        // GET: api/Szakmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Szakma>> GetSzakma(string id)
        {
            var szakma = await _context.Szakmak.FindAsync(id);

            if (szakma == null)
            {
                return NotFound();
            }

            return szakma;
        }

        // PUT: api/Szakmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSzakma(string id, Szakma szakma)
        {
            if (id != szakma.Id)
            {
                return BadRequest();
            }

            _context.Entry(szakma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SzakmaExists(id))
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

        // POST: api/Szakmas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Szakma>> PostSzakma(Szakma szakma)
        {
            _context.Szakmak.Add(szakma);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SzakmaExists(szakma.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSzakma", new { id = szakma.Id }, szakma);
        }

        // DELETE: api/Szakmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSzakma(string id)
        {
            var szakma = await _context.Szakmak.FindAsync(id);
            if (szakma == null)
            {
                return NotFound();
            }

            _context.Szakmak.Remove(szakma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SzakmaExists(string id)
        {
            return _context.Szakmak.Any(e => e.Id == id);
        }
    }
}
