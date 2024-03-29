﻿using ContosoSchool.Application.Services.AuthService;
using ContosoSchool.Application.Services.UserService;
using ContosoSchool.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ContosoSchool.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController
            (
                ApplicationDbContext context, 
                IUserService userService,
                IAuthService authService
            )
        {
            this.context = context;
            _userService = userService;
            _authService = authService;
        }

        [HttpGet, Authorize]
        public ActionResult<object> GetMe()
        {
            var userName = _userService.GetMyName();
            var name = _userService.GetAnyName("Hammad Arshad");
            return Ok(new { userName, name });

            //var username = User?.Identity?.Name;
            //var username2 = User?.FindFirstValue(ClaimTypes.Name);
            //var role = User?.FindFirstValue(ClaimTypes.Role);
            //return Ok(new { username, username2, role });
        }


        [HttpPost(ApiRoutes.Auth.Register)]
        public async Task<ActionResult<UserResponse>> Register(UserDto request)
        {

            if (request.Username == "" || request.Username == null)
                return BadRequest("Something wrong!");

            if (_authService.UserNameExsist(request.Username))
                return BadRequest("Username is already exsist");

            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = request.Role
            };

            string token = _authService.CreateToken(user);
            user.token = token;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var response = new UserResponse
            {
                Status = true,
                Message = "Registered Successfully",
                User = user,
            };

            return Ok(response);
        }


        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<ActionResult<UserResponse>> Login([FromForm][Required]string username, [FromForm][Required]string password)
        {
            if (!_authService.UserNameExsist(username))
            {
                return BadRequest("User Not Found!");
            }

            var userObj = await context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();

            if (userObj == null)
                return NotFound();

            if (!_authService.VerifyPasswordHash(password, userObj.PasswordHash, userObj.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }

            string token = _authService.CreateToken(userObj);
            userObj.token = token;
            await context.SaveChangesAsync();

            var response = new UserResponse
            {
                Status = true,
                Message = "loggedIn Successfully",
                User = userObj
            };

            return Ok(response);
        }
    }
}
