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
    public class StudentAttendanceStatusController : ControllerBase
    {
        private readonly JarvisDbContext _context;

        public StudentAttendanceStatusController(JarvisDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentAttendanceStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentAttendanceStatus>>> GetStudentAttendanceStatuses()
        {
          if (_context.StudentAttendanceStatuses == null)
          {
              return NotFound();
          }
            return await _context.StudentAttendanceStatuses.ToListAsync();
        }

        // GET: api/StudentAttendanceStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAttendanceStatus>> GetStudentAttendanceStatus(Guid id)
        {
          if (_context.StudentAttendanceStatuses == null)
          {
              return NotFound();
          }
            var studentAttendanceStatus = await _context.StudentAttendanceStatuses.FindAsync(id);

            if (studentAttendanceStatus == null)
            {
                return NotFound();
            }

            return studentAttendanceStatus;
        }

        // PUT: api/StudentAttendanceStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAttendanceStatus(Guid id, StudentAttendanceStatus studentAttendanceStatus)
        {
            if (id != studentAttendanceStatus.StudentAttendanceStatusId)
            {
                return BadRequest();
            }

            _context.Entry(studentAttendanceStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAttendanceStatusExists(id))
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

        // POST: api/StudentAttendanceStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentAttendanceStatus>> PostStudentAttendanceStatus(StudentAttendanceStatus studentAttendanceStatus)
        {
          if (_context.StudentAttendanceStatuses == null)
          {
              return Problem("Entity set 'JarvisDbContext.StudentAttendanceStatuses'  is null.");
          }
            _context.StudentAttendanceStatuses.Add(studentAttendanceStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentAttendanceStatusExists(studentAttendanceStatus.StudentAttendanceStatusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentAttendanceStatus", new { id = studentAttendanceStatus.StudentAttendanceStatusId }, studentAttendanceStatus);
        }

        // DELETE: api/StudentAttendanceStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAttendanceStatus(Guid id)
        {
            if (_context.StudentAttendanceStatuses == null)
            {
                return NotFound();
            }
            var studentAttendanceStatus = await _context.StudentAttendanceStatuses.FindAsync(id);
            if (studentAttendanceStatus == null)
            {
                return NotFound();
            }

            _context.StudentAttendanceStatuses.Remove(studentAttendanceStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentAttendanceStatusExists(Guid id)
        {
            return (_context.StudentAttendanceStatuses?.Any(e => e.StudentAttendanceStatusId == id)).GetValueOrDefault();
        }
    }
}
