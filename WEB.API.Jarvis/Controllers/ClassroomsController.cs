using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Context;
using WEB.API.Jarvis.Models;
using Jarvis.WEB.API.Models;
using Jarvis.WEB.API.Context;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public ClassroomsController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
        {
          if (_context.Classrooms == null)
          {
              return NotFound();
          }
            return await _context.Classrooms.ToListAsync();
        }

        // GET: api/Classrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(Guid id)
        {
          if (_context.Classrooms == null)
          {
              return NotFound();
          }
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }

            return classroom;
        }

        // PUT: api/Classrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroom(Guid id, Classroom classroom)
        {
            if (id != classroom.ClassroomId)
            {
                return BadRequest();
            }

            _context.Entry(classroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomExists(id))
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

        // POST: api/Classrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
          if (_context.Classrooms == null)
          {
              return Problem("Entity set 'JarvisDbContext.Classrooms'  is null.");
          }
            _context.Classrooms.Add(classroom);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClassroomExists(classroom.ClassroomId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClassroom", new { id = classroom.ClassroomId }, classroom);
        }

        // DELETE: api/Classrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(Guid id)
        {
            if (_context.Classrooms == null)
            {
                return NotFound();
            }
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassroomExists(Guid id)
        {
            return (_context.Classrooms?.Any(e => e.ClassroomId == id)).GetValueOrDefault();
        }
    }
}
