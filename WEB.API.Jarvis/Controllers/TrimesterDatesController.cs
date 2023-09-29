using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.WEB.API.Context;
using Jarvis.WEB.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Context;
using WEB.API.Jarvis.Models;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrimesterDatesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public TrimesterDatesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/TrimesterDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimesterDate>>> GetTrimesterDates()
        {
          if (_context.TrimesterDates == null)
          {
              return NotFound();
          }
            return await _context.TrimesterDates.ToListAsync();
        }

        // GET: api/TrimesterDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimesterDate>> GetTrimesterDate(Guid id)
        {
          if (_context.TrimesterDates == null)
          {
              return NotFound();
          }
            var trimesterDate = await _context.TrimesterDates.FindAsync(id);

            if (trimesterDate == null)
            {
                return NotFound();
            }

            return trimesterDate;
        }

        // PUT: api/TrimesterDates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimesterDate(Guid id, TrimesterDate trimesterDate)
        {
            if (id != trimesterDate.TrimesterDateId)
            {
                return BadRequest();
            }

            _context.Entry(trimesterDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimesterDateExists(id))
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

        // POST: api/TrimesterDates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrimesterDate>> PostTrimesterDate(TrimesterDate trimesterDate)
        {
          if (_context.TrimesterDates == null)
          {
              return Problem("Entity set 'JarvisDbContext.TrimesterDates'  is null.");
          }
            _context.TrimesterDates.Add(trimesterDate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrimesterDateExists(trimesterDate.TrimesterDateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrimesterDate", new { id = trimesterDate.TrimesterDateId }, trimesterDate);
        }

        // DELETE: api/TrimesterDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrimesterDate(Guid id)
        {
            if (_context.TrimesterDates == null)
            {
                return NotFound();
            }
            var trimesterDate = await _context.TrimesterDates.FindAsync(id);
            if (trimesterDate == null)
            {
                return NotFound();
            }

            _context.TrimesterDates.Remove(trimesterDate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrimesterDateExists(Guid id)
        {
            return (_context.TrimesterDates?.Any(e => e.TrimesterDateId == id)).GetValueOrDefault();
        }
    }
}
