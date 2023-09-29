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
    public class AttendancesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public AttendancesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/Attendances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendances()
        {
            string methodName = "GetAttendances";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Attendances == null)
            {
                LoggerService.LogException(methodName, Request, "Attendance Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Attendance Not Found"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return await _context.Attendances.Where(attendance => attendance.DeletedDate == null).ToListAsync();
        }

        // GET: api/Attendances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendance(Guid id)
        {
            string methodName = "GetAttendance";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Attendances == null)
            {
                LoggerService.LogException(methodName, Request, "Attendance Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Attendance Not Found"
                                    }
                    );
            }
            var attendance = await _context.Attendances.FindAsync(id);

            if (attendance == null)
            {
                LoggerService.LogException(methodName, Request, "Attendance Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Attendance Not Found"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return attendance;
        }

        // PUT: api/Attendances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendance(Guid id, Attendance attendance)
        {
            string methodName = "PutAttendance";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);
            if (id != attendance.AttendanceId)
            {
                LoggerService.LogException(methodName, Request, "Attendance Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Attendance are not the same"
                                    }
                    );
            }


            attendance.UpdatedDate = DateTime.Now;
            attendance.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(attendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!AttendanceExists(id))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status404NotFound,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Attendance Not Found"
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
                                            Message = "Attendance Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Attendance Updated Sucessfully"
                                }
                );
        }

        // POST: api/Attendances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
        {
            string methodName = "PostAttendance";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Attendances == null)
            {
                LoggerService.LogException(methodName, Request, "Attendance Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Attendance was not send"
                                    }
                    );
            }

            attendance.AttendanceId = Guid.NewGuid();
            attendance.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            attendance.CreatedDate = DateTime.Now;

            _context.Attendances.Add(attendance);

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
                                        Message = "Attendance Conflict With Db Exception"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Attendance Created Sucessfully"
                                }
                );
        }

        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(Guid id)
        {
            string methodName = "DeleteAttendance";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Attendances == null)
            {
                LoggerService.LogException(methodName, Request, "Attendance Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Attendance Not Found"
                                    }
                    );
            }
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                LoggerService.LogException(methodName, Request, "Attendance Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Attendance Not Found"
                                    }
                    );
            }
            attendance.DeletedBy = Request.Headers["Requester-Jarvis"].ToString();
            attendance.DeletedDate = DateTime.Now;

            _context.Entry(attendance).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Attendance Deleted Sucessfully"
                                }
                );
        }

        private bool AttendanceExists(Guid id)
        {
            return (_context.Attendances?.Any(e => e.AttendanceId == id)).GetValueOrDefault();
        }
    }
}
