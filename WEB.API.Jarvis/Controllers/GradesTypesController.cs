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
    public class GradesTypesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public GradesTypesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/GradesTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradesType>>> GetGradesTypes()
        {
            string methodName = "GetGrade Types";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.GradesTypes == null)
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
            return await _context.GradesTypes.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/GradesTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradesType>> GetGradesType(Guid id)
        {
            string methodName = "GetGrade Types";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.GradesTypes == null)
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
            var gradesType = await _context.GradesTypes.FindAsync(id);

            if (gradesType == null)
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
            return gradesType;
        }

        // PUT: api/GradesTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradesType(Guid id, GradesType gradesType)
        {
            string methodName = "GetGrade Types";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != gradesType.GradeTypeId)
            {
                LoggerService.LogException(methodName, Request, "Grade Type Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Grade Type are not the same"
                                    }
                    );
            }

            gradesType.UpdatedDate = DateTime.Now;
            gradesType.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(gradesType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!GradesTypeExists(id))
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
                                            Message = "Grade Type Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Grade Type Updated Sucessfully"
                                }
                );
        }

        // POST: api/GradesTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GradesType>> PostGradesType(GradesType gradesType)
        {
            string methodName = "GetGrade Types";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.GradesTypes == null)
            {
                LoggerService.LogException(methodName, Request, "Grade Type Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Grade Type was not send"
                                    }
                    );
            }

            gradesType.GradeTypeId = Guid.NewGuid();
            gradesType.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            gradesType.CreatedDate = DateTime.Now;

            _context.GradesTypes.Add(gradesType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (GradesTypeExists(gradesType.GradeTypeId))
                {
                LoggerService.LogException(methodName, Request, ex.Message, startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status409Conflict,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Grade Type Conflict With Db Exception"
                                    }
                    );
                }

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Grade Type Created Sucessfully"
                                }
                );
        }

        // DELETE: api/GradesTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradesType(Guid id)
        {
            string methodName = "GetGrade Types";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.GradesTypes == null)
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
            var gradesType = await _context.GradesTypes.FindAsync(id);
            if (gradesType == null)
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

            _context.GradesTypes.Remove(gradesType);
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Grade Type Deleted Sucessfully"
                                }
                );
        }

        private bool GradesTypeExists(Guid id)
        {
            return (_context.GradesTypes?.Any(e => e.GradeTypeId == id)).GetValueOrDefault();
        }
    }
}
