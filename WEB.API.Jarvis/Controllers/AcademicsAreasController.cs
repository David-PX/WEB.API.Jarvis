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
    public class AcademicsAreasController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public AcademicsAreasController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/AcademicsAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicArea>>> GetAcademicAreas()
        {
            string methodName = "GetAcademicAreas";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.AcademicAreas == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Area Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Area Not Found"
                                    }
                    );
            }
            LoggerService.LogActionEnd(methodName, startTime);
            return await _context.AcademicAreas.Where(academicArea => academicArea.DeletedDate == null).ToListAsync();
        }

        // GET: api/AcademicsAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicArea>> GetAcademicArea(string id)
        {
            string methodName = "GetAcademicArea";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);
            if (_context.AcademicAreas == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Area Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Area Not Found"
                                    }
                    );
            }
            var academicArea = await _context.AcademicAreas.FindAsync(id);

            if (academicArea == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Area Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Area Not Found"
                                    }
                    );
            }
            LoggerService.LogActionEnd(methodName, startTime);
            return academicArea;
        }

        // PUT: api/AcademicsAreas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicArea(string id, AcademicArea academicArea)
        {
            string methodName = "PutAcademicArea";
            DateTime startTime = DateTime.Now;

            LoggerService.LogActionStart(methodName, Request);
            if (id != academicArea.AcademicAreaId)
            {
                LoggerService.LogException(methodName, Request, "Academic Area Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Academic Area are not the same"
                                    }
                    );
            }

            academicArea.UpdatedDate = DateTime.Now;
            academicArea.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(academicArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!AcademicAreaExists(id))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status404NotFound,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Academic Area Not Found"
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
                                            Message = "Academic Area Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Academic Area Updated Sucessfully"
                                }
                );
        }

        // POST: api/AcademicsAreas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicArea>> PostAcademicArea(AcademicArea academicArea)
        {
            string methodName = "PostAcademicArea";

            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.AcademicAreas == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Area Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Academic Area was not send"
                                    }
                    );
            }

            academicArea.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            academicArea.CreatedDate = DateTime.Now;
            _context.AcademicAreas.Add(academicArea);

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
                                        Message = "Academic Area Conflict With Db Exception"
                                    }
                    );

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Academic Area Created Sucessfully"
                                }
                );
        }

        // DELETE: api/AcademicsAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicArea(string id)
        {
            string methodName = "DeleteAcademicArea";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.AcademicAreas == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Area Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Area Not Found"
                                    }
                    );
            }
            var academicArea = await _context.AcademicAreas.FindAsync(id);
            if (academicArea == null)
            {
                LoggerService.LogException(methodName, Request, "Academic Area Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Academic Area Not Found"
                                    }
                    );
            }

            academicArea.DeletedBy = Request.Headers["Requester-Jarvis"].ToString();
            academicArea.DeletedDate = DateTime.Now;

            _context.Entry(academicArea).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Academic Area Deleted Sucessfully"
                                }
                );
        }

        private bool AcademicAreaExists(string id)
        {
            return (_context.AcademicAreas?.Any(e => e.AcademicAreaId == id)).GetValueOrDefault();
        }
    }
}
