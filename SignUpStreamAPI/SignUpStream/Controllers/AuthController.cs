using Microsoft.AspNetCore.Mvc;
using SignUpStream.Infra.Models;
using SignUpStream.Infra.Interfaces;

namespace SignUpStream.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody]UserVM user)
        {
            var result = await _authService.SignUp(user);
            if (result.Succeeded) return Ok(result);
            else return Ok(result);
        }
    }
}

