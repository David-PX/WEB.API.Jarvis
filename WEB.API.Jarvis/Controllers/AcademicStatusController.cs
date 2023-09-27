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
    public class AcademicStatusController : ControllerBase
    {
        private readonly JarvisDbContext _context;

        public AcademicStatusController(JarvisDbContext context)
        {
            _context = context;
        }

        // GET: api/AcademicStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicStatus>>> GetAcademicStatuses()
        {
          if (_context.AcademicStatuses == null)
          {
              return NotFound();
          }
            return await _context.AcademicStatuses.ToListAsync();
        }

        // GET: api/AcademicStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicStatus>> GetAcademicStatus(Guid id)
        {
          if (_context.AcademicStatuses == null)
          {
              return NotFound();
          }
            var academicStatus = await _context.AcademicStatuses.FindAsync(id);

            if (academicStatus == null)
            {
                return NotFound();
            }

            return academicStatus;
        }

        // PUT: api/AcademicStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicStatus(Guid id, AcademicStatus academicStatus)
        {
            if (id != academicStatus.AcademicStatusId)
            {
                return BadRequest();
            }

            _context.Entry(academicStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicStatusExists(id))
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

        // POST: api/AcademicStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicStatus>> PostAcademicStatus(AcademicStatus academicStatus)
        {
          if (_context.AcademicStatuses == null)
          {
              return Problem("Entity set 'JarvisDbContext.AcademicStatuses'  is null.");
          }
            _context.AcademicStatuses.Add(academicStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AcademicStatusExists(academicStatus.AcademicStatusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAcademicStatus", new { id = academicStatus.AcademicStatusId }, academicStatus);
        }

        // DELETE: api/AcademicStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicStatus(Guid id)
        {
            if (_context.AcademicStatuses == null)
            {
                return NotFound();
            }
            var academicStatus = await _context.AcademicStatuses.FindAsync(id);
            if (academicStatus == null)
            {
                return NotFound();
            }

            _context.AcademicStatuses.Remove(academicStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcademicStatusExists(Guid id)
        {
            return (_context.AcademicStatuses?.Any(e => e.AcademicStatusId == id)).GetValueOrDefault();
        }
    }
}
