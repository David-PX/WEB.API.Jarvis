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
using WEB.API.Jarvis.Utilities;

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
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.IdentificationTypes == null)
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
            return await _context.IdentificationTypes.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/IdentificationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentificationType>> GetIdentificationType(Guid id)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.IdentificationTypes == null)
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
            var identificationType = await _context.IdentificationTypes.FindAsync(id);

            if (identificationType == null)
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
            return identificationType;
        }

        // PUT: api/IdentificationTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentificationType(Guid id, IdentificationType identificationType)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != identificationType.IdentificationTypeId)
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

            identificationType.UpdatedDate = DateTime.Now;
            identificationType.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(identificationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!IdentificationTypeExists(id))
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

        // POST: api/IdentificationTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdentificationType>> PostIdentificationType(IdentificationType identificationType)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.IdentificationTypes == null)
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

            identificationType.IdentificationTypeId = Guid.NewGuid();
            identificationType.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            identificationType.CreatedDate = DateTime.Now;

            _context.IdentificationTypes.Add(identificationType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (IdentificationTypeExists(identificationType.IdentificationTypeId))
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

        // DELETE: api/IdentificationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentificationType(Guid id)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.IdentificationTypes == null)
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
            var identificationType = await _context.IdentificationTypes.FindAsync(id);
            if (identificationType == null)
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

            _context.IdentificationTypes.Remove(identificationType);
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

        private bool IdentificationTypeExists(Guid id)
        {
            return (_context.IdentificationTypes?.Any(e => e.IdentificationTypeId == id)).GetValueOrDefault();
        }
    }
}
