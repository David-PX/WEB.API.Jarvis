using Jarvis.WEB.API.Context;
using Jarvis.WEB.API.Models;
using Jarvis.WEB.API.Utilities;
using Mail.Service.Models;
using Mail.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.API.Jarvis.Models;
using WEB.API.Jarvis.Utilities;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "GENERAL_ADMIN")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly JarvisFullDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;


        public EnrollmentsController(JarvisFullDbContext context, IEmailService emailService, IConfiguration configuration, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: api/Enrollments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
        {
            string methodName = "GetEnrollments";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Enrollments == null)
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
            return await _context.Enrollments.Where(x => x.DeletedDate == null).ToListAsync();
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollment(Guid id)
        {
            string methodName = "GetEnrollments";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Enrollments == null)
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
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
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
            return enrollment;
        }

        // PUT: api/Enrollments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollment(Guid id, Enrollment enrollment)
        {
            string methodName = "GetEnrollments";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (id != enrollment.EnrollmentId)
            {
                LoggerService.LogException(methodName, Request, "Enrollment Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status404NotFound,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The ID of Enrollment are not the same"
                                    }
                    );
            }

            enrollment.UpdatedDate = DateTime.Now;
            enrollment.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();

            _context.Entry(enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EnrollmentExists(id))
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
                                            Message = "Enrollment Conflict With Db Exception"
                                        }
                        );
                }
            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status200OK,
                                new Response
                                {
                                    Status = "Ok",
                                    Message = "Enrollment Updated Sucessfully"
                                }
                );
        }

        // POST: api/Enrollments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enrollment>> PostEnrollment(Enrollment enrollment)
        {
            string methodName = "PostEnrollment";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Enrollments == null)
            {
                LoggerService.LogException(methodName, Request, "Enrollment Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Enrollment was not send"
                                    }
                    );
            }

            enrollment.EnrollmentId = Guid.NewGuid();
            enrollment.CreatedBy = Request.Headers["Requester-Jarvis"].ToString();
            enrollment.CreatedDate = DateTime.Now;

            _context.Enrollments.Add(enrollment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (EnrollmentExists(enrollment.EnrollmentId))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status409Conflict,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Enrollment Conflict With Db Exception"
                                        }
                        );
                }

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Enrollment Created Sucessfully"
                                }
                );
        }

        [HttpPost("academicInfo")]
        public async Task<ActionResult<Enrollment>> PostEnrollmentAcademicInfo(Enrollment academicInfo)
        {
            string methodName = "PostEnrollmentAcademicInfo";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Enrollments == null)
            {
                LoggerService.LogException(methodName, Request, "Enrollment Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Enrollment was not send"
                                    }
                    );
            }

            Enrollment enrollment = await _context.Enrollments.FirstOrDefaultAsync(x => x.Email == academicInfo.Email);
            enrollment.CareerId = academicInfo.CareerId;
            enrollment.UpdatedDate = DateTime.Now;

            _context.Enrollments.Update(enrollment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (EnrollmentExists(enrollment.EnrollmentId))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status409Conflict,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Enrollment Conflict With Db Exception"
                                        }
                        );
                }

            }

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Enrollment Created Sucessfully"
                                }
                );
        }

        [HttpGet("EnrollmentRequest/{email}")]
        public async Task<ActionResult> EnrollmentRequest(string email)
        {
            string methodName = "EnrollmentRequest";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Enrollments == null)
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

            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(x => x.Email == email);

            if (enrollment != null)
            {
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status400BadRequest,
                                    new Response
                                    {
                                        Status = "Not found",
                                        Message = "this user is already enrollment"
                                    }
                );
            }


            try
            {
                var message = new Message(new string[] { email! }, "Vuelvete Parte de Nosotros", EmailTemplates.GetEnrollmentEmailTemplate(_configuration["FrontURls:EnrrolmentForm"]!, email));

                _emailService.SendEmail(message);

                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = "Email Send Successfully" });

            }
            catch (Exception ex)
            {
                LoggerService.LogException(methodName, Request, ex.ToString(), startTime);
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Exception", Message = "Something bad happened" });
            }

        }


        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(Guid id)
        {
            string methodName = "GetEnrollments";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (_context.Enrollments == null)
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
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
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

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status202Accepted,
                                new Response
                                {
                                    Status = "Deleted",
                                    Message = "Enrollment Deleted Sucessfully"
                                }
                );
        }

        // POST: api/Enrollments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("UpdateStatusEnrollment")]
        public async Task<ActionResult> UpdateStatusEnrollment([FromBody] UpdateStateStudentParameters parameters)
        {
            string methodName = "UpdateStatusEnrollment";
            DateTime startTime = DateTime.Now;
            LoggerService.LogActionStart(methodName, Request);

            if (parameters.enrollmentId == Guid.Empty)
            {
                LoggerService.LogException(methodName, Request, "Enrollment Bad Request", startTime);
                LoggerService.LogActionEnd(methodName, startTime);
                return StatusCode(StatusCodes.Status406NotAcceptable,
                                    new Response
                                    {
                                        Status = "Bad Request",
                                        Message = "The Enrollment was not send"
                                    }
                    );
            }
            Enrollment enrollment = await _context.Enrollments.FindAsync(parameters.enrollmentId);
            AcademicStatus academicStatus = await _context.AcademicStatuses.Where(academic => academic.AcademicStateName == "Activo").FirstAsync();

            enrollment.IsAdmitted = parameters.state;

            enrollment.UpdatedDate = DateTime.Now;
            enrollment.UpdatedBy = Request.Headers["Requester-Jarvis"].ToString();
            Student student = new Student()
            {
                StudentId = "123",
                CareerId = enrollment.CareerId,
                EnrollmentId = enrollment.EnrollmentId,
                AcademicStatusId = academicStatus.AcademicStatusId,
                CreatedBy = Request.Headers["Requester-Jarvis"].ToString(),
                CreatedDate = DateTime.Now,
            };

            _context.Entry(enrollment).State = EntityState.Modified;
            _context.Students.Add(student);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (EnrollmentExists(enrollment.EnrollmentId))
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status409Conflict,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Enrollment Conflict With Db Exception"
                                        }
                        );
                }

            }


            if (enrollment.IsAdmitted == true)
            {
                try
                {
                    var userExist = await _userManager.FindByEmailAsync(enrollment.Email);
                    if (userExist != null)
                    {
                        LoggerService.LogActionEnd(methodName, startTime);
                        return StatusCode(StatusCodes.Status403Forbidden,
                            new Response { Status = "Error", Message = "User already exists!" });
                    }

                    IdentityUser newUser = new()
                    {
                        Email = enrollment.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = enrollment.Email
                    };

                    string provisionalPwd = PwdGenerator.GetRandomPassword();

                    var result = await _userManager.CreateAsync(newUser, provisionalPwd);
                    if (!result.Succeeded)
                    {
                        LoggerService.LogActionEnd(methodName, startTime);
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            new Response { Status = "Error", Message = "User Failed to Create!" });
                    }

                    await _userManager.AddToRoleAsync(newUser, "STUDENT");
                    await _context.SaveChangesAsync();
                    //Add Toke to verify the email...
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    //var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = newUser.Email }, Request.Scheme);
                    var message = new Message(new string[] { enrollment.Email! }, "Activate Account Email", EmailTemplates.GetAdmittedStudentLoginTemplate(provisionalPwd, enrollment.Email));
                    _emailService.SendEmail(message);

                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status201Created,
                            new Response { Status = "Success", Message = "User Created Successfully!" });
                }
                catch(Exception ex)
                {
                    LoggerService.LogException(methodName, Request, ex.Message, startTime);
                    LoggerService.LogActionEnd(methodName, startTime);
                    return StatusCode(StatusCodes.Status409Conflict,
                                        new Response
                                        {
                                            Status = "Not found",
                                            Message = "Enrollment Conflict With Db Exception"
                                        }
                        );
                }
            }

           
            LoggerService.LogActionEnd(methodName, startTime);
            return StatusCode(StatusCodes.Status201Created,
                                new Response
                                {
                                    Status = "Created",
                                    Message = "Student Created Sucessfully"
                                }
                );
        }

        public class UpdateStateStudentParameters
        {
            public Guid enrollmentId { get; set; }
            public bool state { get; set; }
        }

        private bool EnrollmentExists(Guid id)
        {
            return (_context.Enrollments?.Any(e => e.EnrollmentId == id)).GetValueOrDefault();
        }
    }
}
