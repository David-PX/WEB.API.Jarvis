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
    public class SectionSchedulesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public SectionSchedulesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/SectionSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionSchedule>>> GetSectionSchedules()
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.SectionSchedules == null)
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
            return await _context.SectionSchedules.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/SectionSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionSchedule>> GetSectionSchedule(Guid id)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.SectionSchedules == null)
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
            var sectionSchedule = await _context.SectionSchedules.FindAsync(id);

            if (sectionSchedule == null)
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
            return sectionSchedule;
        }

        // PUT: api/SectionSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSectionSchedule(Guid id, SectionSchedule sectionSchedule)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != sectionSchedule.SectionScheduleId)
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

            sectionSchedule.UpdatedDate = DateTime.Now;
            sectionSchedule.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(sectionSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!SectionScheduleExists(id))
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

        // POST: api/SectionSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SectionSchedule>> PostSectionSchedule(SectionSchedule sectionSchedule)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.SectionSchedules == null)
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

            sectionSchedule.SectionScheduleId = Guid.NewGuid();
            sectionSchedule.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            sectionSchedule.CreatedDate = DateTime.Now;
            
            _context.SectionSchedules.Add(sectionSchedule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (SectionScheduleExists(sectionSchedule.SectionScheduleId))
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

        // DELETE: api/SectionSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSectionSchedule(Guid id)
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.SectionSchedules == null)
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
            var sectionSchedule = await _context.SectionSchedules.FindAsync(id);
            if (sectionSchedule == null)
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

            _context.SectionSchedules.Remove(sectionSchedule);
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

        private bool SectionScheduleExists(Guid id)
        {
            return (_context.SectionSchedules?.Any(e => e.SectionScheduleId == id)).GetValueOrDefault();
        }
    }
}
