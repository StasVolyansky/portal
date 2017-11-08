using App.System;
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
        private readonly SystemManager systemManager;

        public AuthController(TokenService tokenService, SystemManager systemManager)
        {
            this.tokenService = tokenService;
            this.systemManager = systemManager;
        }

        [HttpPost]
        public IActionResult GetToken([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!systemManager.CheckCredentials(model.Login, model.Password))
                return BadRequest();

            var results = new
            {
                token = tokenService.CreateToken(model.Login)
            };

            return Created("", results);
        }
    }
}