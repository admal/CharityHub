using CharityHub.Domain.Models.UserModels;
using CharityHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityHub.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService userService;
        private ICryptographyService cryptographyService;

        public UserController(
            IUserService userService, 
            ICryptographyService cryptographyService)
        {
            this.userService = userService;
            this.cryptographyService = cryptographyService;
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn([FromBody]SignInInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            string passwordHash = cryptographyService.GetHashString(inputModel.Password);

            var user = userService.GetUser(inputModel.EmailAddress, passwordHash);

            if (user == null)
            {
                NotFound("User not found");
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp([FromBody]SignUpInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var user = userService.Add(inputModel);

            if(user == null)
            {
                BadRequest("Cannot add to db");
            }

            return Ok();
        }
    }
}
