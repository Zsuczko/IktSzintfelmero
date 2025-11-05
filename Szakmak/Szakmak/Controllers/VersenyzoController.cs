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
    public class VersenyzoController : ControllerBase
    {
        private readonly SzakmakDbContext _context;

        public VersenyzoController(SzakmakDbContext context)
        {
            _context = context;
        }

        // GET: api/Versenyzo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Versenyzo>>> GetVersenyzok()
        {
            return await _context.Versenyzok.ToListAsync();
        }

        // GET: api/Versenyzo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Versenyzo>> GetVersenyzo(int id)
        {
            var versenyzo = await _context.Versenyzok.FindAsync(id);

            if (versenyzo == null)
            {
                return NotFound();
            }

            return versenyzo;
        }

        // PUT: api/Versenyzo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVersenyzo(int id, Versenyzo versenyzo)
        {
            if (id != versenyzo.Id)
            {
                return BadRequest();
            }

            _context.Entry(versenyzo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersenyzoExists(id))
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

        // POST: api/Versenyzo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Versenyzo>> PostVersenyzo(Versenyzo versenyzo)
        {
            _context.Versenyzok.Add(versenyzo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVersenyzo", new { id = versenyzo.Id }, versenyzo);
        }

        // DELETE: api/Versenyzo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVersenyzo(int id)
        {
            var versenyzo = await _context.Versenyzok.FindAsync(id);
            if (versenyzo == null)
            {
                return NotFound();
            }

            _context.Versenyzok.Remove(versenyzo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VersenyzoExists(int id)
        {
            return _context.Versenyzok.Any(e => e.Id == id);
        }
    }
}
