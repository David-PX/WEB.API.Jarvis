using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    public class EmployeesSchedulesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public EmployeesSchedulesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeesSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeesSchedule>>> GetEmployeesSchedules()
        {
            string methodName = "GetEmployee Schedules";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.EmployeesSchedules == null)
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
            return await _context.EmployeesSchedules.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/EmployeesSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeesSchedule>> GetEmployeesSchedule(Guid id)
        {
            string methodName = "GetEmployee Schedules";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.EmployeesSchedules == null)
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
            var employeesSchedule = await _context.EmployeesSchedules.FindAsync(id);

            if (employeesSchedule == null)
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
            return employeesSchedule;
        }

        // PUT: api/EmployeesSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeesSchedule(Guid id, EmployeesSchedule employeesSchedule)
        {
            string methodName = "GetEmployee Schedules";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != employeesSchedule.EmployeesSchedulesId)
            {
                LoggerService.LogException(methodName, Request, "Employee Schedule Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Employee Schedule are not the same"
                                    }
                );
            }

            employeesSchedule.UpdatedDate = DateTime.Now;
            employeesSchedule.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(employeesSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EmployeesScheduleExists(id))
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
                                            Message = "Employee Schedule Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Employee Schedule Updated Sucessfully"
                                }
                );
        }

        // POST: api/EmployeesSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeesSchedule>> PostEmployeesSchedule(EmployeesSchedule employeesSchedule)
        {
            string methodName = "GetEmployee Schedules";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.EmployeesSchedules == null)
            {
                LoggerService.LogException(methodName, Request, "Employee Schedule Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Employee Schedule was not send"
                                    }
                    );
            }

            employeesSchedule.EmployeesSchedulesId = Guid.NewGuid();
            employeesSchedule.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            employeesSchedule.CreatedDate = DateTime.Now;

            _context.EmployeesSchedules.Add(employeesSchedule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (EmployeesScheduleExists(employeesSchedule.EmployeesSchedulesId))
                {
                LoggerService.LogException(methodName, Request, ex.Message, startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status409Conflict,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Employee Schedule Conflict With Db Exception"
                                    }
                    );
                }

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Employee Schedule Created Sucessfully"
                                }
                );
        }

        // DELETE: api/EmployeesSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeesSchedule(Guid id)
        {
            string methodName = "GetEmployee Schedules";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.EmployeesSchedules == null)
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
            var employeesSchedule = await _context.EmployeesSchedules.FindAsync(id);
            if (employeesSchedule == null)
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

            _context.EmployeesSchedules.Remove(employeesSchedule);
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Employee Schedule Deleted Sucessfully"
                                }
                );
        }

        private bool EmployeesScheduleExists(Guid id)
        {
            return (_context.EmployeesSchedules?.Any(e => e.EmployeesSchedulesId == id)).GetValueOrDefault();
        }
    }
}
