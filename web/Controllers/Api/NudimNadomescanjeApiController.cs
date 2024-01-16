using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using web.Filters;

namespace web.Controllers_Api
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class NudimNadomescanjeApiController : ControllerBase
    {
        private readonly oaContext _context;

        public NudimNadomescanjeApiController(oaContext context)
        {
            _context = context;
        }

        // GET: api/NudimNadomescanjeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NudimNadomescanje>>> GetNudimNadomescanje()
        {
            return await _context.NudimNadomescanje.ToListAsync();
        }

        // GET: api/NudimNadomescanjeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NudimNadomescanje>> GetNudimNadomescanje(int id)
        {
            var nudimNadomescanje = await _context.NudimNadomescanje.FindAsync(id);

            if (nudimNadomescanje == null)
            {
                return NotFound();
            }

            return nudimNadomescanje;
        }

        // PUT: api/NudimNadomescanjeApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNudimNadomescanje(int id, NudimNadomescanje nudimNadomescanje)
        {
            if (id != nudimNadomescanje.ID)
            {
                return BadRequest();
            }

            _context.Entry(nudimNadomescanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NudimNadomescanjeExists(id))
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

        // POST: api/NudimNadomescanjeApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NudimNadomescanje>> PostNudimNadomescanje(NudimNadomescanje nudimNadomescanje)
        {
            _context.NudimNadomescanje.Add(nudimNadomescanje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNudimNadomescanje", new { id = nudimNadomescanje.ID }, nudimNadomescanje);
        }

        // DELETE: api/NudimNadomescanjeApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNudimNadomescanje(int id)
        {
            var nudimNadomescanje = await _context.NudimNadomescanje.FindAsync(id);
            if (nudimNadomescanje == null)
            {
                return NotFound();
            }

            _context.NudimNadomescanje.Remove(nudimNadomescanje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NudimNadomescanjeExists(int id)
        {
            return _context.NudimNadomescanje.Any(e => e.ID == id);
        }
    }
}
