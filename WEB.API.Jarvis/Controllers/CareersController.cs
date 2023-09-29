using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Context;
using Jarvis.WEB.API.Models;
using Jarvis.WEB.API.Context;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareersController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public CareersController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/Careers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Career>>> GetCareers()
        {
          if (_context.Careers == null)
          {
              return NotFound();
          }
            return await _context.Careers.ToListAsync();
        }

        // GET: api/Careers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Career>> GetCareer(Guid id)
        {
          if (_context.Careers == null)
          {
              return NotFound();
          }
            var career = await _context.Careers.FindAsync(id);

            if (career == null)
            {
                return NotFound();
            }

            return career;
        }

        // PUT: api/Careers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareer(Guid id, Career career)
        {
            if (id != career.CareerId)
            {
                return BadRequest();
            }

            _context.Entry(career).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerExists(id))
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

        // POST: api/Careers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Career>> PostCareer(Career career)
        {
          if (_context.Careers == null)
          {
              return Problem("Entity set 'JarvisDbContext.Careers'  is null.");
          }
            _context.Careers.Add(career);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CareerExists(career.CareerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCareer", new { id = career.CareerId }, career);
        }

        // DELETE: api/Careers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareer(Guid id)
        {
            if (_context.Careers == null)
            {
                return NotFound();
            }
            var career = await _context.Careers.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }

            _context.Careers.Remove(career);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CareerExists(Guid id)
        {
            return (_context.Careers?.Any(e => e.CareerId == id)).GetValueOrDefault();
        }
    }
}
