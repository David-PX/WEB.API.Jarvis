using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Context;
using WEB.API.Jarvis.Models;
using Jarvis.WEB.API.Models;
using Jarvis.WEB.API.Context;
using WEB.API.Jarvis.Utilities;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "GENERAL_ADMIN")]
    public class ClassroomsController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public ClassroomsController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
        {
            string methodName = "GetClassrooms";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);
            if (_context.Classrooms == null)
            {
                LoggerService.LogException(methodName, Request, "Classroom Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Classroom Not Found"
                                    }
                    );
            }
            LoggerService.LogActionEnd(methodName, startTime);
            return await _context.Classrooms.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/Classrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(Guid id)
        {
            string methodName = "GetClassroom";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Classrooms == null)
            {
                LoggerService.LogException(methodName, Request, "Classroom Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Classroom Not Found"
                                    }
                    );
            }
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                LoggerService.LogException(methodName, Request, "Classroom Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Classroom Not Found"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return classroom;
        }

        // PUT: api/Classrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroom(Guid id, Classroom classroom)
        {
            string methodName = "PutClassroom";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != classroom.ClassroomId)
            {
                LoggerService.LogException(methodName, Request, "Classroom Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Classroom are not the same"
                                    }
                    );
            }

            classroom.UpdatedDate = DateTime.Now;
            classroom.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();
            _context.Entry(classroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ClassroomExists(id))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status404NotFound,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Classroom Not Found"
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
                                            Message = "Classroom Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Classroom Updated Sucessfully"
                                }
                );
        }

        // POST: api/Classrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
            string methodName = "PostClassroom";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Classrooms == null)
            {
                LoggerService.LogException(methodName, Request, "Classroom Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Classroom was not send"
                                    }
                    );
            }

            classroom.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            classroom.CreatedDate = DateTime.Now;

            _context.Classrooms.Add(classroom);
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
                                        Message = "Classroom Conflict With Db Exception"
                                    }
                    );

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Classroom Created Sucessfully"
                                }
                );
        }

        // DELETE: api/Classrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(Guid id)
        {
            string methodName = "DeleteClassroom";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Classrooms == null)
            {
                LoggerService.LogException(methodName, Request, "Classroom Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Classroom Not Found"
                                    }
                    );
            }
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                LoggerService.LogException(methodName, Request, "Classroom Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Classroom Not Found"
                                    }
                    );
            }

            classroom.DeletedBy = Request.Headers["Requester-Jarvis"].ToString();
            classroom.DeletedDate = DateTime.Now;

            _context.Entry(classroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Classroom Deleted Sucessfully"
                                }
                );
        }

        private bool ClassroomExists(Guid id)
        {
            return (_context.Classrooms?.Any(e => e.ClassroomId == id)).GetValueOrDefault();
        }
    }
}
