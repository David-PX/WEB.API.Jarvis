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
    public class AcademicsAreasController : ControllerBase
    {
        private readonly JarvisDbContext _context;

        public AcademicsAreasController(JarvisDbContext context)
        {
            _context = context;
        }

        // GET: api/AcademicsAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicArea>>> GetAcademicAreas()
        {
          if (_context.AcademicAreas == null)
          {
              return NotFound();
          }
            return await _context.AcademicAreas.ToListAsync();
        }

        // GET: api/AcademicsAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicArea>> GetAcademicArea(string id)
        {
          if (_context.AcademicAreas == null)
          {
              return NotFound();
          }
            var academicArea = await _context.AcademicAreas.FindAsync(id);

            if (academicArea == null)
            {
                return NotFound();
            }

            return academicArea;
        }

        // PUT: api/AcademicsAreas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicArea(string id, AcademicArea academicArea)
        {
            if (id != academicArea.AcademicAreaId)
            {
                return BadRequest();
            }

            _context.Entry(academicArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicAreaExists(id))
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

        // POST: api/AcademicsAreas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicArea>> PostAcademicArea(AcademicArea academicArea)
        {
          if (_context.AcademicAreas == null)
          {
              return Problem("Entity set 'JarvisDbContext.AcademicAreas'  is null.");
          }
            _context.AcademicAreas.Add(academicArea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AcademicAreaExists(academicArea.AcademicAreaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAcademicArea", new { id = academicArea.AcademicAreaId }, academicArea);
        }

        // DELETE: api/AcademicsAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicArea(string id)
        {
            if (_context.AcademicAreas == null)
            {
                return NotFound();
            }
            var academicArea = await _context.AcademicAreas.FindAsync(id);
            if (academicArea == null)
            {
                return NotFound();
            }

            _context.AcademicAreas.Remove(academicArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcademicAreaExists(string id)
        {
            return (_context.AcademicAreas?.Any(e => e.AcademicAreaId == id)).GetValueOrDefault();
        }
    }
}
