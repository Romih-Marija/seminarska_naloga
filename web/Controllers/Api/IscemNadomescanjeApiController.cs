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
    public class IscemNadomescanjeApiController : ControllerBase
    {
        private readonly oaContext _context;

        public IscemNadomescanjeApiController(oaContext context)
        {
            _context = context;
        }

        // GET: api/IscemNadomescanjeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IscemNadomescanje>>> GetIscemNadomescanje()
        {
            return await _context.IscemNadomescanje.ToListAsync();
        }
        // GET: api/IscemNadomescanjeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IscemNadomescanje>> GetIscemNadomescanje(int id)
        {
            var iscemNadomescanje = await _context.IscemNadomescanje.FindAsync(id);

            if (iscemNadomescanje == null)
            {
                return NotFound();
            }

            return iscemNadomescanje;
        }

        // PUT: api/IscemNadomescanjeApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIscemNadomescanje(int id, IscemNadomescanje iscemNadomescanje)
        {
            if (id != iscemNadomescanje.ID)
            {
                return BadRequest();
            }

            _context.Entry(iscemNadomescanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IscemNadomescanjeExists(id))
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

        // POST: api/IscemNadomescanjeApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IscemNadomescanje>> PostIscemNadomescanje(IscemNadomescanje iscemNadomescanje)
        {
            _context.IscemNadomescanje.Add(iscemNadomescanje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIscemNadomescanje", new { id = iscemNadomescanje.ID }, iscemNadomescanje);
        }

        // DELETE: api/IscemNadomescanjeApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIscemNadomescanje(int id)
        {
            var iscemNadomescanje = await _context.IscemNadomescanje.FindAsync(id);
            if (iscemNadomescanje == null)
            {
                return NotFound();
            }

            _context.IscemNadomescanje.Remove(iscemNadomescanje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IscemNadomescanjeExists(int id)
        {
            return _context.IscemNadomescanje.Any(e => e.ID == id);
        }
    }
}
