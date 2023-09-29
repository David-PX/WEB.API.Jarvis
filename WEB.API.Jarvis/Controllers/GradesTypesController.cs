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
    public class GradesTypesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public GradesTypesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/GradesTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradesType>>> GetGradesTypes()
        {
          if (_context.GradesTypes == null)
          {
              return NotFound();
          }
            return await _context.GradesTypes.ToListAsync();
        }

        // GET: api/GradesTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradesType>> GetGradesType(Guid id)
        {
          if (_context.GradesTypes == null)
          {
              return NotFound();
          }
            var gradesType = await _context.GradesTypes.FindAsync(id);

            if (gradesType == null)
            {
                return NotFound();
            }

            return gradesType;
        }

        // PUT: api/GradesTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradesType(Guid id, GradesType gradesType)
        {
            if (id != gradesType.GradeTypeId)
            {
                return BadRequest();
            }

            _context.Entry(gradesType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradesTypeExists(id))
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

        // POST: api/GradesTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GradesType>> PostGradesType(GradesType gradesType)
        {
          if (_context.GradesTypes == null)
          {
              return Problem("Entity set 'JarvisDbContext.GradesTypes'  is null.");
          }
            _context.GradesTypes.Add(gradesType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GradesTypeExists(gradesType.GradeTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGradesType", new { id = gradesType.GradeTypeId }, gradesType);
        }

        // DELETE: api/GradesTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradesType(Guid id)
        {
            if (_context.GradesTypes == null)
            {
                return NotFound();
            }
            var gradesType = await _context.GradesTypes.FindAsync(id);
            if (gradesType == null)
            {
                return NotFound();
            }

            _context.GradesTypes.Remove(gradesType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradesTypeExists(Guid id)
        {
            return (_context.GradesTypes?.Any(e => e.GradeTypeId == id)).GetValueOrDefault();
        }
    }
}
