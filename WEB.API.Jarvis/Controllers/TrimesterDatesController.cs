using System;
using System.Collections.Generic;
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
    public class TrimesterDatesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public TrimesterDatesController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/TrimesterDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrimesterDate>>> GetTrimesterDates()
        {
            string methodName = "GetTrimester Dates";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.TrimesterDates == null)
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
            return await _context.TrimesterDates.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/TrimesterDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrimesterDate>> GetTrimesterDate(Guid id)
        {
            string methodName = "GetTrimester Dates";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.TrimesterDates == null)
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
            var trimesterDate = await _context.TrimesterDates.FindAsync(id);

            if (trimesterDate == null)
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
            return trimesterDate;
        }

        // PUT: api/TrimesterDates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrimesterDate(Guid id, TrimesterDate trimesterDate)
        {
            string methodName = "GetTrimester Dates";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != trimesterDate.TrimesterDateId)
            {
                LoggerService.LogException(methodName, Request, "Trimester Date Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Trimester Date are not the same"
                                    }
                    );
            }

            trimesterDate.UpdatedDate = DateTime.Now;
            trimesterDate.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(trimesterDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!TrimesterDateExists(id))
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
                                            Message = "Trimester Date Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Trimester Date Updated Sucessfully"
                                }
                );
        }

        // POST: api/TrimesterDates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrimesterDate>> PostTrimesterDate(TrimesterDate trimesterDate)
        {
            string methodName = "GetTrimester Dates";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.TrimesterDates == null)
            {
                LoggerService.LogException(methodName, Request, "Trimester Date Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Trimester Date was not send"
                                    }
                    );
            }

            trimesterDate.TrimesterDateId = Guid.NewGuid();
            trimesterDate.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            trimesterDate.CreatedDate = DateTime.Now;

            _context.TrimesterDates.Add(trimesterDate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (TrimesterDateExists(trimesterDate.TrimesterDateId))
                {
                LoggerService.LogException(methodName, Request, ex.Message, startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status409Conflict,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Trimester Date Conflict With Db Exception"
                                    }
                    );
                }

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Trimester Date Created Sucessfully"
                                }
                );
        }

        // DELETE: api/TrimesterDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrimesterDate(Guid id)
        {
            string methodName = "GetTrimester Dates";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.TrimesterDates == null)
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
            var trimesterDate = await _context.TrimesterDates.FindAsync(id);
            if (trimesterDate == null)
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

            _context.TrimesterDates.Remove(trimesterDate);
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Trimester Date Deleted Sucessfully"
                                }
                );
        }

        private bool TrimesterDateExists(Guid id)
        {
            return (_context.TrimesterDates?.Any(e => e.TrimesterDateId == id)).GetValueOrDefault();
        }
    }
}
