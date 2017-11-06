using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Web.System.Models;
using Portal.Web.System.Services;

namespace Portal.Web.Administration
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : Controller
    {
        private readonly TokenService tokenService;

        public AuthController(TokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult GetToken([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var results = new
            {
                token = tokenService.CreateToken(model.Login)
            };

            return Created("", results);
        }
    }
}