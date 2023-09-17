﻿using Mail.Service.Models;
using Mail.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEB.API.Jarvis.Context;
using WEB.API.Jarvis.Models;
using WEB.API.Jarvis.Models.Authentication.Login;
using WEB.API.Jarvis.Models.Authentication.ResetPassword;
using WEB.API.Jarvis.Models.Authentication.SignUp;

namespace WEB.API.Jarvis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _context;

        public AuthenticationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IConfiguration configuration, IEmailService emailService, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser user)
        {
            var userExist = await _userManager.FindByEmailAsync(user.Email);
            if (userExist != null) 
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User already exists!" });
            }

            IdentityUser newUser = new()
            {
                Email = user.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = user.Email
            };

            

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User Failed to Create!" });
            }

            await _userManager.AddToRoleAsync(newUser,"Huesped");
            await _context.SaveChangesAsync();

            //Add Toke to verify the email...
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = newUser.Email }, Request.Scheme);
            var message = new Message(new string[] { user.Email! }, "Confirmation Email Link", confirmationLink!);
            _emailService.SendEmail(message);


            return StatusCode(StatusCodes.Status201Created,
                    new Response { Status = "Success", Message = "User Created Successfully!" });

        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = " Success", Message = "Email Verified Successfully" });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                   new Response { Status = "Error", Message = "This user does not exist" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password)) 
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var userRoles = await _userManager.GetRolesAsync(user);

                foreach(var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var jwtToken = GetToken(authClaims);

                //var userInfo = await _context.Guests.FirstOrDefaultAsync(x => x.UserID == user.Id);

                return Ok(new 
                {
                    //id = userInfo.ID,
                    //names = userInfo.Names,
                    //lastnames = userInfo.LastNames,
                    //phoneNumber = userInfo.PhoneNumber,
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                });
            }
            return Unauthorized();
        }


        [HttpPost("ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(ResetPassword dto)
        {
            // Validate the input.
            if (dto.UserId == null || dto.UserId == 0)
            {
                return BadRequest("UserId is required.");
            }

            if (string.IsNullOrEmpty(dto.oldPassword))
            {
                return BadRequest("Old password is required.");
            }

            if (string.IsNullOrEmpty(dto.newPassword))
            {
                return BadRequest("New password is required.");
            }

            if (string.IsNullOrEmpty(dto.confirmPassword))
            {
                return BadRequest("Confirm password is required.");
            }

            if (dto.newPassword != dto.confirmPassword)
            {
                return BadRequest("New password and confirm password do not match.");
            }

            //var guest = await _context.Guests.FindAsync(dto.UserId);
            // Get the user.
            var user = await _userManager.FindByIdAsync("");

            // Validate the old password.
            if (!await _userManager.CheckPasswordAsync(user, dto.oldPassword))
            {
                return BadRequest("Old password is incorrect.");
            }

            // Change the password.
            await _userManager.ChangePasswordAsync(user, dto.oldPassword, dto.newPassword);

            // Return success.
            return Ok();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaim)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
