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
    public class ObjavaIscemOaApiController : ControllerBase
    {
        private readonly oaContext _context;

        public ObjavaIscemOaApiController(oaContext context)
        {
            _context = context;
        }

        // GET: api/ObjavaIscemOaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjavaIscemOa>>> GetObjaveIscemOa()
        {
            return await _context.ObjaveIscemOa.ToListAsync();
        }

        // GET: api/ObjavaIscemOaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjavaIscemOa>> GetObjavaIscemOa(int id)
        {
            var objavaIscemOa = await _context.ObjaveIscemOa.FindAsync(id);

            if (objavaIscemOa == null)
            {
                return NotFound();
            }

            return objavaIscemOa;
        }

        // PUT: api/ObjavaIscemOaApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjavaIscemOa(int id, ObjavaIscemOa objavaIscemOa)
        {
            if (id != objavaIscemOa.ID)
            {
                return BadRequest();
            }

            _context.Entry(objavaIscemOa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjavaIscemOaExists(id))
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

        // POST: api/ObjavaIscemOaApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObjavaIscemOa>> PostObjavaIscemOa(ObjavaIscemOa objavaIscemOa)
        {
            _context.ObjaveIscemOa.Add(objavaIscemOa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjavaIscemOa", new { id = objavaIscemOa.ID }, objavaIscemOa);
        }

        // DELETE: api/ObjavaIscemOaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjavaIscemOa(int id)
        {
            var objavaIscemOa = await _context.ObjaveIscemOa.FindAsync(id);
            if (objavaIscemOa == null)
            {
                return NotFound();
            }

            _context.ObjaveIscemOa.Remove(objavaIscemOa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjavaIscemOaExists(int id)
        {
            return _context.ObjaveIscemOa.Any(e => e.ID == id);
        }
    }
}
