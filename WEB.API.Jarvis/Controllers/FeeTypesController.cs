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
    public class FeeTypesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public FeeTypesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/FeeTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeeType>>> GetFeeTypes()
        {
          if (_context.FeeTypes == null)
          {
              return NotFound();
          }
            return await _context.FeeTypes.ToListAsync();
        }

        // GET: api/FeeTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeeType>> GetFeeType(Guid id)
        {
          if (_context.FeeTypes == null)
          {
              return NotFound();
          }
            var feeType = await _context.FeeTypes.FindAsync(id);

            if (feeType == null)
            {
                return NotFound();
            }

            return feeType;
        }

        // PUT: api/FeeTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeeType(Guid id, FeeType feeType)
        {
            if (id != feeType.FeeTypeId)
            {
                return BadRequest();
            }

            _context.Entry(feeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeeTypeExists(id))
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

        // POST: api/FeeTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeeType>> PostFeeType(FeeType feeType)
        {
          if (_context.FeeTypes == null)
          {
              return Problem("Entity set 'JarvisDbContext.FeeTypes'  is null.");
          }
            _context.FeeTypes.Add(feeType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FeeTypeExists(feeType.FeeTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFeeType", new { id = feeType.FeeTypeId }, feeType);
        }

        // DELETE: api/FeeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeeType(Guid id)
        {
            if (_context.FeeTypes == null)
            {
                return NotFound();
            }
            var feeType = await _context.FeeTypes.FindAsync(id);
            if (feeType == null)
            {
                return NotFound();
            }

            _context.FeeTypes.Remove(feeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeeTypeExists(Guid id)
        {
            return (_context.FeeTypes?.Any(e => e.FeeTypeId == id)).GetValueOrDefault();
        }
    }
}
