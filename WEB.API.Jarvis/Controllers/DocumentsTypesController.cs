using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.WEB.API.Context;
using Jarvis.WEB.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Context;
using WEB.API.Jarvis.Models;
using WEB.API.Jarvis.Utilities;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "GENERAL_ADMIN")]
    public class DocumentsTypesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public DocumentsTypesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/DocumentsTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentsType>>> GetDocumentsTypes()
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.DocumentsTypes == null)
            {
                LoggerService.LogException(methodName, Request, "Building Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Building Not Found"
                                    }
                    );
            }
            LoggerService.LogActionEnd(methodName, startTime);
            return await _context.DocumentsTypes.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/DocumentsTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentsType>> GetDocumentsType(Guid id)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.DocumentsTypes == null)
            {
                LoggerService.LogException(methodName, Request, "Career Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Career Not Found"
                                    }
                    );
            }
            var documentsType = await _context.DocumentsTypes.FindAsync(id);

            if (documentsType == null)
            {
                LoggerService.LogException(methodName, Request, "Career Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Career Not Found"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return documentsType;
        }

        // PUT: api/DocumentsTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentsType(Guid id, DocumentsType documentsType)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != documentsType.DocumentTypeId)
            {
                LoggerService.LogException(methodName, Request, "Building Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Building are not the same"
                                    }
                );
            }

            documentsType.UpdatedDate = DateTime.Now;
            documentsType.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(documentsType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!DocumentsTypeExists(id))
                {
                    LoggerService.LogException(methodName, Request, "Career Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Career Not Found"
                                    }
                    );
                }
                else
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status409Conflict,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Building Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Building Updated Sucessfully"
                                }
                );
        }

        // POST: api/DocumentsTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentsType>> PostDocumentsType(DocumentsType documentsType)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.DocumentsTypes == null)
            {
                LoggerService.LogException(methodName, Request, "Building Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Building was not send"
                                    }
                    );
            }

            documentsType.DocumentTypeId = Guid.NewGuid();
            documentsType.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            documentsType.CreatedDate = DateTime.Now;

            _context.DocumentsTypes.Add(documentsType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (DocumentsTypeExists(documentsType.DocumentTypeId))
                {
                LoggerService.LogException(methodName, Request, ex.Message, startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status409Conflict,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Building Conflict With Db Exception"
                                    }
                    );
                }

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Building Created Sucessfully"
                                }
                );
        }

        // DELETE: api/DocumentsTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentsType(Guid id)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.DocumentsTypes == null)
            {
                LoggerService.LogException(methodName, Request, "Career Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Career Not Found"
                                    }
                    );
            }
            var documentsType = await _context.DocumentsTypes.FindAsync(id);
            if (documentsType == null)
            {
                LoggerService.LogException(methodName, Request, "Career Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Career Not Found"
                                    }
                    );
            }

            _context.DocumentsTypes.Remove(documentsType);
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Building Deleted Sucessfully"
                                }
                );
        }

        private bool DocumentsTypeExists(Guid id)
        {
            return (_context.DocumentsTypes?.Any(e => e.DocumentTypeId == id)).GetValueOrDefault();
        }
    }
}
