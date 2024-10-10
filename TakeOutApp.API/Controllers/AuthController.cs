using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeOutApp.API.Helpers;
using TakeOutApp.API.Models;
using TakeOutApp.API.Services;
using TakeOutApp.API.ViewModels;

namespace TakeOutApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(AuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(loginVM);
            var token = await _authService.LoginAsync(user);

            if (token == null)
            {
                return NotFound();
            }

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (await _authService.IsUserExist(registerVM.PhoneNumber))
            {
                return Conflict();
            }

            var user = _mapper.Map<User>(registerVM);

            try
            {
                await _authService.RegisterAsync(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return StatusCode(201);
        }
    }
}
