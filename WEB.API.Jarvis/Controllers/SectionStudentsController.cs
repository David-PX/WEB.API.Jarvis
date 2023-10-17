﻿using Jarvis.WEB.API.Context;
using Jarvis.WEB.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jarvis.WEB.API.Controllers
{
    [Route("api/sectionstudents")]
    [ApiController]
    public class SectionStudentsController : ControllerBase
    {

        private readonly JarvisFullDbContext _context;

        public SectionStudentsController(JarvisFullDbContext context)
        {
            _context = context;
        }

        // GET api/sectionstudents/{studentId}
        [HttpGet("{studentId}")]
        public async Task<ActionResult<IEnumerable<Section>>> GetSectionStudentsByStudentId(string studentId)
        {
            var sectionStudents = _context.SectionStudents
                .Include(ss => ss.Section)
                .Where(ss => ss.StudentId == studentId);

            if(sectionStudents != null)
            {
                sectionStudents = _context.SectionStudents
                .Include(ss => ss.Section)
                .ThenInclude(te => te.Teacher)
                .Include(ss => ss.Section)
                .ThenInclude(su => su.Subject)
                .Where(ss => ss.StudentId == studentId);
            }

            return StatusCode(StatusCodes.Status200OK, sectionStudents);
        }

        // POST api/sectionstudents
        [HttpPost]
        public async Task<IActionResult> CreateSectionStudent(SectionStudent sectionStudent)
        {
            if (sectionStudent == null)
            {
                return BadRequest("Datos no válidos");
            }

            try
            {
                _context.SectionStudents.Add(sectionStudent);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSectionStudentsByStudentId", new { studentId = sectionStudent.StudentId }, sectionStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }

}
