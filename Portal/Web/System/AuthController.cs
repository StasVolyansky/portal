using App.System;
using App.System.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Web.Data;
using Portal.Web.System.Models;
using Portal.Web.System.Services;

namespace Portal.Web.System
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : Controller
    {
        private readonly TokenService tokenService;
        private readonly SystemManager systemManager;
        private readonly DataService dataService;

        public AuthController(TokenService tokenService, SystemManager systemManager, DataService dataService)
        {
            this.tokenService = tokenService;
            this.systemManager = systemManager;
            this.dataService = dataService;
        }

        [HttpPost]
        public IActionResult GetToken([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!systemManager.IsValidCredentials(model.Login, model.Password))
                return BadRequest();

            var results = new
            {
                token = tokenService.CreateToken(model.Login)
            };

            return Created("", results);
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Register([FromBody] RegistrationModel model)
        {
            systemManager.CreateUser(new UserInsertionDto
            {
                Email = model.Email,
                Password = model.Password
            });

            return Ok();
        }

        public IActionResult GetUsers()
        {


            return Ok();
        }
    }
}