using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.DTOs.Account;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using api.DTOs.Account.Owner;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, IAuthService authService, ITokenService tokenService)
        {
            _userManager = userManager;
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(registerDTO);

            if (result.is_authenticated)
            {
                return Ok(new {
                    status = "Success",
                    data = new {
                        name = result.name,
                        email = result.email,
                        roles = result.roles,
                        access_token = result.token,
                        refresh_token = result.refresh_token,
                        refresh_token_expiration = result.refresh_token_expiration
                    }
                });
            }
            else
            {
                return BadRequest(new {
                    status = "Error",
                    message = result.message
                });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(login);

            if(!result.is_authenticated)
            {
                return BadRequest(new {
                    status = "Error",
                    message = result.message
                });
            }

            return Ok(new {
                status = "Success",
                data = new {
                    name = result.name,
                    email = result.email,
                    roles = result.roles,
                    access_token = result.token,
                    refresh_token = result.refresh_token,
                    refresh_token_expiration = result.refresh_token_expiration
                }
            });
        }


        [HttpPost("owner-register")]
        public async Task<IActionResult> OwnerRegister([FromForm] OwnerRegisterDTO OwnerRegisterDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.OwnerRegisterAsync(OwnerRegisterDTO);

            if (result.is_authenticated)
            {
                return Ok(new {
                    status = "Success",
                    data = new {
                        name = result.name,
                        email = result.email,
                        roles = result.role,
                        access_token = result.token,
                        refresh_token = result.refresh_token,
                        refresh_token_expiration = result.refresh_token_expiration
                    }
                });
            }
            else
            {
                return BadRequest(new {
                    status = "Error",
                    message = result.message
                });
            }
        }


        [HttpPost("owner-login")]
        public async Task<IActionResult> OwnerLogin([FromForm] LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.OwnerLoginAsync(login);

            if(!result.is_authenticated)
            {
                return BadRequest(new {
                    status = "Error",
                    message = result.message
                });
            }

            return Ok(new {
                status = "Success",
                data = new {
                    name = result.name,
                    email = result.email,
                    roles = result.role,
                    access_token = result.token,
                    refresh_token = result.refresh_token,
                    refresh_token_expiration = result.refresh_token_expiration
                }
            });
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO refreshTokenRequestDTO)
        {
            var result = await _authService.RefreshTokenAsync(refreshTokenRequestDTO);

            if(!result.is_authenticated)
            {
                return BadRequest(new {
                    status = "Error",
                    message = result.message
                });
            }

            return Ok(new {
                status = "Success",
                data = new {
                    access_token = result.token,
                    refresh_token = result.refresh_token,
                }
            });
        }



        [HttpGet]
        [Authorize]
        public IActionResult HelloWorld()
        {
            return Ok("Hello World!");
        }

        [HttpGet("no-auth")]
        public IActionResult HelloWorld2()
        {
            return Ok("Hello World2!");
        }

        [Authorize(Roles = "Owner")]
        [HttpGet("owner-test")]
        public IActionResult HelloWorld3()
        {
            return Ok("Hello World for owner!");
        }
    }
}