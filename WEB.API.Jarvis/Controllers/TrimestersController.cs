using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Context;
using WEB.API.Jarvis.Models;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrimestersController : ControllerBase
    {
        private readonly JarvisDbContext _context;

        public TrimestersController(JarvisDbContext context)
        {
            _context = context;
        }

        // GET: api/Trimesters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trimester>>> GetTrimesters()
        {
          if (_context.Trimesters == null)
          {
              return NotFound();
          }
            return await _context.Trimesters.ToListAsync();
        }

        // GET: api/Trimesters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trimester>> GetTrimester(Guid id)
        {
          if (_context.Trimesters == null)
          {
              return NotFound();
          }
            var trimester = await _context.Trimesters.FindAsync(id);

            if (trimester == null)
            {
                return NotFound();
            }

            return trimester;
        }

        // PUT: api/Trimesters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimester(Guid id, Trimester trimester)
        {
            if (id != trimester.IdTrimestres)
            {
                return BadRequest();
            }

            _context.Entry(trimester).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimesterExists(id))
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

        // POST: api/Trimesters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trimester>> PostTrimester(Trimester trimester)
        {
          if (_context.Trimesters == null)
          {
              return Problem("Entity set 'JarvisDbContext.Trimesters'  is null.");
          }
            _context.Trimesters.Add(trimester);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrimesterExists(trimester.IdTrimestres))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrimester", new { id = trimester.IdTrimestres }, trimester);
        }

        // DELETE: api/Trimesters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrimester(Guid id)
        {
            if (_context.Trimesters == null)
            {
                return NotFound();
            }
            var trimester = await _context.Trimesters.FindAsync(id);
            if (trimester == null)
            {
                return NotFound();
            }

            _context.Trimesters.Remove(trimester);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrimesterExists(Guid id)
        {
            return (_context.Trimesters?.Any(e => e.IdTrimestres == id)).GetValueOrDefault();
        }
    }
}
