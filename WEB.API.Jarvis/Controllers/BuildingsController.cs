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
    public class BuildingsController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;

        public BuildingsController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET: api/Buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            string methodName = "GetBuildings";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Buildings == null)
            {
                LoggerService.LogException(methodName, Request, "Building Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Building Not Found"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return await _context.Buildings.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/Buildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(string id)
        {

            string methodName = "GetBuilding";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Buildings == null)
            {
                LoggerService.LogException(methodName, Request, "Building Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Building Not Found"
                                    }
                    );
            }
            var building = await _context.Buildings.FindAsync(id);

            if (building == null)
            {
                LoggerService.LogException(methodName, Request, "Building Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Building Not Found"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return building;
        }

        // PUT: api/Buildings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuilding(string id, Building building)
        {
            string methodName = "PutBuilding";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != building.BuildingId)
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

            building.UpdatedDate = DateTime.Now;
            building.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(building).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!BuildingExists(id))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status404NotFound,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Building Not Found"
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

        // POST: api/Buildings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Building>> PostBuilding(Building building)
        {
            string methodName = "PostBuilding";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Buildings == null)
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

            building.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            building.CreatedDate = DateTime.Now;

            _context.Buildings.Add(building);

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
                                        Message = "Building Conflict With Db Exception"
                                    }
                    );
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

        // DELETE: api/Buildings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding(string id)
        {
            string methodName = "DeleteBuilding";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Buildings == null)
            {
                LoggerService.LogException(methodName, Request, "Building Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Building Not Found"
                                    }
                    );
            }
            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
            {
                LoggerService.LogException(methodName, Request, "Building Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "Building Not Found"
                                    }
                    );
            }

            building.DeletedBy = Request.Headers["Requester-Jarvis"].ToString();
            building.DeletedDate = DateTime.Now;

            _context.Entry(building).State = EntityState.Modified;

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

        private bool BuildingExists(string id)
        {
            return (_context.Buildings?.Any(e => e.BuildingId == id)).GetValueOrDefault();
        }
    }
}
