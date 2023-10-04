using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public class AcademicStatusController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public AcademicStatusController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/AcademicStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicStatus>>> GetAcademicStatuses()
        {
            string methodName = "GetAcademicStatuses";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.AcademicStatuses == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Status Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Status Not Found"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return await _context.AcademicStatuses.Where(academicStatus => academicStatus.DeletedDate == null).ToListAsync();
        }

        // GET: api/AcademicStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicStatus>> GetAcademicStatus(Guid id)
        {
            string methodName = "GetAcademicStatus";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);
            if (_context.AcademicStatuses == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Status Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Status Not Found"
                                    }
                    );
            }
            var academicStatus = await _context.AcademicStatuses.FindAsync(id);

            if (academicStatus == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Status Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Status Not Found"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return academicStatus;
        }

        // PUT: api/AcademicStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicStatus(Guid id, AcademicStatus academicStatus)
        {
            string methodName = "PutAcademicStatus";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != academicStatus.AcademicStatusId)
            {
                LoggerService.LogException(methodName, Request, "Academic Status Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Academic Status are not the same"
                                    }
                    );
            }

            academicStatus.UpdatedDate = DateTime.Now;
            academicStatus.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(academicStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!AcademicStatusExists(id))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status404NotFound,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Academic Status Not Found"
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
                                            Message = "Academic Status Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Academic Status Updated Sucessfully"
                                }
                );
        }

        // POST: api/AcademicStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicStatus>> PostAcademicStatus(AcademicStatus academicStatus)
        {
            string methodName = "PostAcademicStatus";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.AcademicStatuses == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Status Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Academic Status was not send"
                                    }
                    );
            }

            academicStatus.AcademicStatusId = Guid.NewGuid();
            academicStatus.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            academicStatus.CreatedDate = DateTime.Now;

            _context.AcademicStatuses.Add(academicStatus);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                LoggerService.LogException(methodName, Request, ex.Message, startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status409Conflict,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Status Conflict With Db Exception"
                                    }
                    );

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Academic Status Created Sucessfully"
                                }
                );
        }

        // DELETE: api/AcademicStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicStatus(Guid id)
        {
            string methodName = "GetAcademicStatuss";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.AcademicStatuses == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Status Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Status Not Found"
                                    }
                    );
            }
            var academicStatus = await _context.AcademicStatuses.FindAsync(id);
            if (academicStatus == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Status Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Status Not Found"
                                    }
                    );
            }

            academicStatus.DeletedBy = Request.Headers["Requester-Jarvis"].ToString();
            academicStatus.DeletedDate = DateTime.Now;

            _context.Entry(academicStatus).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Academic Status Deleted Sucessfully"
                                }
                );
        }

        private bool AcademicStatusExists(Guid id)
        {
            return (_context.AcademicStatuses?.Any(e => e.AcademicStatusId == id)).GetValueOrDefault();
        }
    }
}
