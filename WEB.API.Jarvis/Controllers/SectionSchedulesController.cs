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
    public class SectionSchedulesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public SectionSchedulesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/SectionSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionSchedule>>> GetSectionSchedules()
        {
          if (_context.SectionSchedules == null)
          {
              return NotFound();
          }
            return await _context.SectionSchedules.ToListAsync();
        }

        // GET: api/SectionSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionSchedule>> GetSectionSchedule(Guid id)
        {
          if (_context.SectionSchedules == null)
          {
              return NotFound();
          }
            var sectionSchedule = await _context.SectionSchedules.FindAsync(id);

            if (sectionSchedule == null)
            {
                return NotFound();
            }

            return sectionSchedule;
        }

        // PUT: api/SectionSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSectionSchedule(Guid id, SectionSchedule sectionSchedule)
        {
            if (id != sectionSchedule.SectionScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(sectionSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionScheduleExists(id))
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

        // POST: api/SectionSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SectionSchedule>> PostSectionSchedule(SectionSchedule sectionSchedule)
        {
          if (_context.SectionSchedules == null)
          {
              return Problem("Entity set 'JarvisDbContext.SectionSchedules'  is null.");
          }
            _context.SectionSchedules.Add(sectionSchedule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SectionScheduleExists(sectionSchedule.SectionScheduleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSectionSchedule", new { id = sectionSchedule.SectionScheduleId }, sectionSchedule);
        }

        // DELETE: api/SectionSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSectionSchedule(Guid id)
        {
            if (_context.SectionSchedules == null)
            {
                return NotFound();
            }
            var sectionSchedule = await _context.SectionSchedules.FindAsync(id);
            if (sectionSchedule == null)
            {
                return NotFound();
            }

            _context.SectionSchedules.Remove(sectionSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectionScheduleExists(Guid id)
        {
            return (_context.SectionSchedules?.Any(e => e.SectionScheduleId == id)).GetValueOrDefault();
        }
    }
}
