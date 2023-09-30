using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jarvis.WEB.API.DTOs.DTOs.City;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Context;
using WEB.API.Jarvis.Models;
using Jarvis.WEB.API.Models;
using Jarvis.WEB.API.Context;
using WEB.API.Jarvis.Utilities;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;
        private readonly IMapper _mapper;

        public CitiesController(JarvisFullDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<CityDTO>> GetCities()
        {
            string methodName = "GetCities";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            var cities = await _context.Cities.Where(x => x.DeletedDate == null).ToListAsync();
            if (cities == null)
            {
                LoggerService.LogException(methodName, Request, "City Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "City Not Found"
                                    }
                    );
            }
            var citiesDTO = _mapper.Map<CityDTO>(cities);
            LoggerService.LogActionEnd(methodName, startTime);
            return citiesDTO;
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(Guid id)
        {

            string methodName = "GetCity";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);
            if (_context.Cities == null)
            {
                LoggerService.LogException(methodName, Request, "City Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "City Not Found"
                                    }
                    );
            }
            var city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                LoggerService.LogException(methodName, Request, "City Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "City Not Found"
                                    }
                    );
            }
            LoggerService.LogActionEnd(methodName, startTime);
            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(Guid id, City city)
        {
            string methodName = "PutCity";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);
            if (id != city.CityId)
            {
                LoggerService.LogException(methodName, Request, "City Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of City are not the same"
                                    }
                    );
            }

            city.UpdatedDate = DateTime.Now;
            city.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CityExists(id))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status404NotFound,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "City Not Found"
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
                                            Message = "City Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "City Updated Sucessfully"
                                }
                );
        }

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            string methodName = "PostCity";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Cities == null)
            {
                LoggerService.LogException(methodName, Request, "City Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The City was not send"
                                    }
                    );
            }

            city.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            city.CreatedDate = DateTime.Now;

            _context.Cities.Add(city);
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
                                        Message = "City Conflict With Db Exception"
                                    }
                    );
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "City Created Sucessfully"
                                }
                );
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            string methodName = "DeleteCity";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Cities == null)
            {
                LoggerService.LogException(methodName, Request, "City Not Found", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "City Not Found"
                                    }
                    );
            }
            var city = await _context.Cities.FindAsync(id);
            city.DeletedBy = Request.Headers["Requester-Jarvis"].ToString();
            city.DeletedDate = DateTime.Now;

            _context.Entry(city).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "City Deleted Sucessfully"
                                }
                );
        }

        private bool CityExists(Guid id)
        {
            return (_context.Cities?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}
