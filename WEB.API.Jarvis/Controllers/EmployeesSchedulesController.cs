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
    public class EmployeesSchedulesController : ControllerBase
    {
        private readonly JarvisDbContext _context;

        public EmployeesSchedulesController(JarvisDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeesSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeesSchedule>>> GetEmployeesSchedules()
        {
          if (_context.EmployeesSchedules == null)
          {
              return NotFound();
          }
            return await _context.EmployeesSchedules.ToListAsync();
        }

        // GET: api/EmployeesSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeesSchedule>> GetEmployeesSchedule(Guid id)
        {
          if (_context.EmployeesSchedules == null)
          {
              return NotFound();
          }
            var employeesSchedule = await _context.EmployeesSchedules.FindAsync(id);

            if (employeesSchedule == null)
            {
                return NotFound();
            }

            return employeesSchedule;
        }

        // PUT: api/EmployeesSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeesSchedule(Guid id, EmployeesSchedule employeesSchedule)
        {
            if (id != employeesSchedule.EmployeesSchedulesId)
            {
                return BadRequest();
            }

            _context.Entry(employeesSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesScheduleExists(id))
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

        // POST: api/EmployeesSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeesSchedule>> PostEmployeesSchedule(EmployeesSchedule employeesSchedule)
        {
          if (_context.EmployeesSchedules == null)
          {
              return Problem("Entity set 'JarvisDbContext.EmployeesSchedules'  is null.");
          }
            _context.EmployeesSchedules.Add(employeesSchedule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeesScheduleExists(employeesSchedule.EmployeesSchedulesId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeesSchedule", new { id = employeesSchedule.EmployeesSchedulesId }, employeesSchedule);
        }

        // DELETE: api/EmployeesSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeesSchedule(Guid id)
        {
            if (_context.EmployeesSchedules == null)
            {
                return NotFound();
            }
            var employeesSchedule = await _context.EmployeesSchedules.FindAsync(id);
            if (employeesSchedule == null)
            {
                return NotFound();
            }

            _context.EmployeesSchedules.Remove(employeesSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesScheduleExists(Guid id)
        {
            return (_context.EmployeesSchedules?.Any(e => e.EmployeesSchedulesId == id)).GetValueOrDefault();
        }
    }
}
