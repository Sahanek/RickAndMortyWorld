using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        /// <summary>
        /// UserManager oraz SignInManager używane do zarządzania użytkownikami.
        /// </summary>
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Funkcja pobiera email z ClaimTypes w tokenie, który przesyłany jest w nagłówku,
        /// a następnie zwraca na jego podstawie zalogowanego użytkownika
        /// </summary>
        /// <returns>Zwraca użytkownika z Tokenem</returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {

            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);
            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                UserName = user.UserName
            };

        }

        /// <summary>
        /// Funkcja sprawdza czy dany email istnieje w bazie danych
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true/false</returns>
        [HttpGet("emailexists")]
        [SwaggerOperation(Summary = "e.g. localhost:5001/api/account/emailexists?email=greg@test.com")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }

        /// <summary>
        /// Funkcja służąca do logowania.
        /// Sprawdza czy użytkownik o takim emailu istnieje
        /// Następnie sprawdza poprawność hasła
        /// Jeśli logowanie przemyślnie pomyślnie zwraca usera z Tokenem
        /// w przeciwnym przypadku Unauthorized lub BadRequest
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
           
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null) return BadRequest();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
            };
        }
        /// <summary>
        /// Tworzy nowego użytkownika jeśli email jest nie zajęty
        /// zwraca użytkownika wraz z tokenem.
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if ((await CheckEmailExistsAsync(registerDto.Email)).Value) return BadRequest();

            var user = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(); // We can do it better

            return new UserDto
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
            };
        }
    }
}
