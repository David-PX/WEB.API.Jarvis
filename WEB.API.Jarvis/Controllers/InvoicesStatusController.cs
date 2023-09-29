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
    public class InvoicesStatusController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public InvoicesStatusController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoicesStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoicesStatus>>> GetInvoicesStatuses()
        {
          if (_context.InvoicesStatuses == null)
          {
              return NotFound();
          }
            return await _context.InvoicesStatuses.ToListAsync();
        }

        // GET: api/InvoicesStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoicesStatus>> GetInvoicesStatus(Guid id)
        {
          if (_context.InvoicesStatuses == null)
          {
              return NotFound();
          }
            var invoicesStatus = await _context.InvoicesStatuses.FindAsync(id);

            if (invoicesStatus == null)
            {
                return NotFound();
            }

            return invoicesStatus;
        }

        // PUT: api/InvoicesStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoicesStatus(Guid id, InvoicesStatus invoicesStatus)
        {
            if (id != invoicesStatus.InvoiceStatusId)
            {
                return BadRequest();
            }

            _context.Entry(invoicesStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicesStatusExists(id))
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

        // POST: api/InvoicesStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoicesStatus>> PostInvoicesStatus(InvoicesStatus invoicesStatus)
        {
          if (_context.InvoicesStatuses == null)
          {
              return Problem("Entity set 'JarvisDbContext.InvoicesStatuses'  is null.");
          }
            _context.InvoicesStatuses.Add(invoicesStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InvoicesStatusExists(invoicesStatus.InvoiceStatusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInvoicesStatus", new { id = invoicesStatus.InvoiceStatusId }, invoicesStatus);
        }

        // DELETE: api/InvoicesStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoicesStatus(Guid id)
        {
            if (_context.InvoicesStatuses == null)
            {
                return NotFound();
            }
            var invoicesStatus = await _context.InvoicesStatuses.FindAsync(id);
            if (invoicesStatus == null)
            {
                return NotFound();
            }

            _context.InvoicesStatuses.Remove(invoicesStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoicesStatusExists(Guid id)
        {
            return (_context.InvoicesStatuses?.Any(e => e.InvoiceStatusId == id)).GetValueOrDefault();
        }
    }
}
