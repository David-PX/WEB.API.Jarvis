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
    public class StudentAttendanceStatusController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public StudentAttendanceStatusController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentAttendanceStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentAttendanceStatus>>> GetStudentAttendanceStatuses()
        {
            string methodName = "GetStudent Attendances";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.StudentAttendanceStatuses == null)
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
            return await _context.StudentAttendanceStatuses.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/StudentAttendanceStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAttendanceStatus>> GetStudentAttendanceStatus(Guid id)
        {
            string methodName = "GetStudent Attendances";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.StudentAttendanceStatuses == null)
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
            var studentAttendanceStatus = await _context.StudentAttendanceStatuses.FindAsync(id);

            if (studentAttendanceStatus == null)
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
            return studentAttendanceStatus;
        }

        // PUT: api/StudentAttendanceStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAttendanceStatus(Guid id, StudentAttendanceStatus studentAttendanceStatus)
        {
            string methodName = "GetStudent Attendances";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != studentAttendanceStatus.StudentAttendanceStatusId)
            {
                LoggerService.LogException(methodName, Request, "Student Attendance Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Student Attendance are not the same"
                                    }
                    );
            }

            studentAttendanceStatus.UpdatedDate = DateTime.Now;
            studentAttendanceStatus.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(studentAttendanceStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!StudentAttendanceStatusExists(id))
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
                                            Message = "Student Attendance Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Student Attendance Updated Sucessfully"
                                }
                );
        }

        // POST: api/StudentAttendanceStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentAttendanceStatus>> PostStudentAttendanceStatus(StudentAttendanceStatus studentAttendanceStatus)
        {
            string methodName = "GetStudent Attendances";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.StudentAttendanceStatuses == null)
            {
                LoggerService.LogException(methodName, Request, "Student Attendance Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Student Attendance was not send"
                                    }
                    );
            }

            studentAttendanceStatus.StudentAttendanceStatusId = Guid.NewGuid();
            studentAttendanceStatus.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            studentAttendanceStatus.CreatedDate = DateTime.Now;

            _context.StudentAttendanceStatuses.Add(studentAttendanceStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (StudentAttendanceStatusExists(studentAttendanceStatus.StudentAttendanceStatusId))
                {
                LoggerService.LogException(methodName, Request, ex.Message, startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status409Conflict,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Student Attendance Conflict With Db Exception"
                                    }
                    );
                }

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Student Attendance Created Sucessfully"
                                }
                );
        }

        // DELETE: api/StudentAttendanceStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAttendanceStatus(Guid id)
        {
            string methodName = "GetStudent Attendances";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.StudentAttendanceStatuses == null)
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
            var studentAttendanceStatus = await _context.StudentAttendanceStatuses.FindAsync(id);
            if (studentAttendanceStatus == null)
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

            _context.StudentAttendanceStatuses.Remove(studentAttendanceStatus);
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Student Attendance Deleted Sucessfully"
                                }
                );
        }

        private bool StudentAttendanceStatusExists(Guid id)
        {
            return (_context.StudentAttendanceStatuses?.Any(e => e.StudentAttendanceStatusId == id)).GetValueOrDefault();
        }
    }
}
