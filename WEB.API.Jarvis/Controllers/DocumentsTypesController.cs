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
    public class DocumentsTypesController : ControllerBase
    {
        private readonly JarvisDbContext _context;

        public DocumentsTypesController(JarvisDbContext context)
        {
            _context = context;
        }

        // GET: api/DocumentsTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentsType>>> GetDocumentsTypes()
        {
          if (_context.DocumentsTypes == null)
          {
              return NotFound();
          }
            return await _context.DocumentsTypes.ToListAsync();
        }

        // GET: api/DocumentsTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentsType>> GetDocumentsType(Guid id)
        {
          if (_context.DocumentsTypes == null)
          {
              return NotFound();
          }
            var documentsType = await _context.DocumentsTypes.FindAsync(id);

            if (documentsType == null)
            {
                return NotFound();
            }

            return documentsType;
        }

        // PUT: api/DocumentsTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentsType(Guid id, DocumentsType documentsType)
        {
            if (id != documentsType.DocumentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(documentsType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentsTypeExists(id))
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

        // POST: api/DocumentsTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentsType>> PostDocumentsType(DocumentsType documentsType)
        {
          if (_context.DocumentsTypes == null)
          {
              return Problem("Entity set 'JarvisDbContext.DocumentsTypes'  is null.");
          }
            _context.DocumentsTypes.Add(documentsType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocumentsTypeExists(documentsType.DocumentTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocumentsType", new { id = documentsType.DocumentTypeId }, documentsType);
        }

        // DELETE: api/DocumentsTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentsType(Guid id)
        {
            if (_context.DocumentsTypes == null)
            {
                return NotFound();
            }
            var documentsType = await _context.DocumentsTypes.FindAsync(id);
            if (documentsType == null)
            {
                return NotFound();
            }

            _context.DocumentsTypes.Remove(documentsType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentsTypeExists(Guid id)
        {
            return (_context.DocumentsTypes?.Any(e => e.DocumentTypeId == id)).GetValueOrDefault();
        }
    }
}
