using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Context;
using Jarvis.WEB.API.Models;
using Jarvis.WEB.API.Context;
using WEB.API.Jarvis.Utilities;
using WEB.API.Jarvis.Models;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareersController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public CareersController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/Careers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Career>>> GetCareers()
        {
            string methodName = "GetCareers";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Careers == null)
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

            return await _context.Careers.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/Careers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Career>> GetCareer(Guid id)
        {

            string methodName = "GetCareer";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Careers == null)
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
            var career = await _context.Careers.FindAsync(id);

            if (career == null)
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
            return career;
        }

        // PUT: api/Careers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareer(Guid id, Career career)
        {
            string methodName = "PutCareer";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != career.CareerId)
            {
                LoggerService.LogException(methodName, Request, "Career Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Career are not the same"
                                    }
                    );
            }

            career.UpdatedDate = DateTime.Now;
            career.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();
            _context.Entry(career).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CareerExists(id))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
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
                                            Message = "Career Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Career Updated Sucessfully"
                                }
                );
        }

        // POST: api/Careers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Career>> PostCareer(Career career)
        {
            string methodName = "PostCareer";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Careers == null)
            {
                LoggerService.LogException(methodName, Request, "Career Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Career was not send"
                                    }
                    );
            }

            career.CareerId = Guid.NewGuid();
            career.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            career.CreatedDate = DateTime.Now;

            _context.Careers.Add(career);
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
                                        Message = "Career Conflict With Db Exception"
                                    }
                    );

            }


            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Career Created Sucessfully"
                                }
                );
        }

        // DELETE: api/Careers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareer(Guid id)
        {
            string methodName = "DeleteCareer";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Careers == null)
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
            var career = await _context.Careers.FindAsync(id);
            if (career == null)
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

            career.DeletedBy = Request.Headers["Requester-Jarvis"].ToString();
            career.DeletedDate = DateTime.Now;

            _context.Entry(career).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Career Deleted Sucessfully"
                                }
                );
        }

        private bool CareerExists(Guid id)
        {
            return (_context.Careers?.Any(e => e.CareerId == id)).GetValueOrDefault();
        }
    }
}
