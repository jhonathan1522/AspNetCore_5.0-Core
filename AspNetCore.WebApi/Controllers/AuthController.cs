using AspNetCore.Entities.DTO_S;
using AspNetCore.Services;
using AspNetCore.WebApi.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ITokenHandlerService _service;

        public AuthController(UserManager<IdentityUser> userManager,ITokenHandlerService service)
        {
            _userManager = userManager;
            _service = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto user)
        {
            // Si el objeto es valido
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser != null)
                {
                    return BadRequest("El correo electronico ingresado ya exite");
                }


                var isCreate = await _userManager.CreateAsync(new IdentityUser() { Email = user.Email, UserName = user.Name }, user.Password);

                if (isCreate.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(isCreate.Errors.Select(x => x.Description).ToList());
                }
            }
            else 
            {
                return BadRequest("Se produjo algun error al registrar un usuario");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto user) 
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    return BadRequest(new UserLoginResponseDto()
                    {
                        Login = false,
                        Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrecto"
                        }
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if (isCorrect)
                {
                    var pars = new TokenParameters()
                    {
                        Id = existingUser.Id,
                        PasswordHash = existingUser.PasswordHash,
                        Username = existingUser.UserName
                    };

                    var jwtToken = _service.GenerateJwtToken(pars);
                    return Ok(new UserLoginResponseDto()
                    {

                        Login = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new UserLoginResponseDto()
                    {
                        Login = false,
                        Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrecto"
                        }
                    });
                }
            }
            else 
            {
                return BadRequest(new UserLoginResponseDto()
                {
                    Login = false,
                    Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrecto"
                        }
                });
            }
        }




    }
}
