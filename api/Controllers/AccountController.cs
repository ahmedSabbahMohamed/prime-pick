using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.DTOs.Account;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                AppUser NewUser = new AppUser
                {
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email,
                    PhoneNumber = registerDTO.Phone
                };

                var createduser = await _userManager.CreateAsync(NewUser, registerDTO.Password);

                if (createduser.Succeeded)
                {
                    var result = await _userManager.AddToRoleAsync(NewUser, "User");

                    if (result.Succeeded)
                    {
                        return Ok(_tokenService.CreateToken(NewUser));
                    }
                    else
                        return StatusCode(500, result.Errors);
                }
                else
                    return StatusCode(500, createduser.Errors);
                

            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> LogInUser([FromForm] LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AppUser? user = await _userManager.FindByNameAsync(login.UserName);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, login.Password))
                {
                    return Ok(new {
                        Username = login.UserName,
                        Token = _tokenService.CreateToken(user)
                    });
                }
                else
                    return Unauthorized();
            }
            else
                ModelState.AddModelError("", "Username is Invalid");
            
            return Ok();
        }

    }
}