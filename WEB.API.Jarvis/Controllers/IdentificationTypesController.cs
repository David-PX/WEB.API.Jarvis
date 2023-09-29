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
    public class IdentificationTypesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public IdentificationTypesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/IdentificationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentificationType>>> GetIdentificationTypes()
        {
          if (_context.IdentificationTypes == null)
          {
              return NotFound();
          }
            return await _context.IdentificationTypes.ToListAsync();
        }

        // GET: api/IdentificationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentificationType>> GetIdentificationType(Guid id)
        {
          if (_context.IdentificationTypes == null)
          {
              return NotFound();
          }
            var identificationType = await _context.IdentificationTypes.FindAsync(id);

            if (identificationType == null)
            {
                return NotFound();
            }

            return identificationType;
        }

        // PUT: api/IdentificationTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentificationType(Guid id, IdentificationType identificationType)
        {
            if (id != identificationType.IdentificationTypeId)
            {
                return BadRequest();
            }

            _context.Entry(identificationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentificationTypeExists(id))
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

        // POST: api/IdentificationTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdentificationType>> PostIdentificationType(IdentificationType identificationType)
        {
          if (_context.IdentificationTypes == null)
          {
              return Problem("Entity set 'JarvisDbContext.IdentificationTypes'  is null.");
          }
            _context.IdentificationTypes.Add(identificationType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IdentificationTypeExists(identificationType.IdentificationTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIdentificationType", new { id = identificationType.IdentificationTypeId }, identificationType);
        }

        // DELETE: api/IdentificationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentificationType(Guid id)
        {
            if (_context.IdentificationTypes == null)
            {
                return NotFound();
            }
            var identificationType = await _context.IdentificationTypes.FindAsync(id);
            if (identificationType == null)
            {
                return NotFound();
            }

            _context.IdentificationTypes.Remove(identificationType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdentificationTypeExists(Guid id)
        {
            return (_context.IdentificationTypes?.Any(e => e.IdentificationTypeId == id)).GetValueOrDefault();
        }
    }
}
