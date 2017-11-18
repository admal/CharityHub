using CharityHub.Domain.Models.UserModels;
using CharityHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityHub.Domain.Models.Charity;
using CharityHub.Services.CharityService;

namespace CharityHub.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICryptographyService _cryptographyService;
        private ICharityService _charityService;

        public UserController(
            IUserService userService, 
            ICryptographyService cryptographyService, 
            ICharityService charityService)
        {
            this._userService = userService;
            this._cryptographyService = cryptographyService;
            _charityService = charityService;
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn([FromBody]SignInInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            string passwordHash = _cryptographyService.GetHashString(inputModel.Password);

            var user = _userService.GetUser(inputModel.EmailAddress, passwordHash);
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

            var user = _userService.Add(inputModel);
            if (inputModel.AddOrganisation)
            {
                _charityService.AddCharity(new CharityAddEditModel()
                {
                    OwnerId = user.Id,
                    Name = inputModel.OrganizationName,
                    Description = inputModel.OrganizationDescription,
                    Category = inputModel.OrganizationType
                });
            }

            if (user == null)
            {
                BadRequest("Cannot add to db");
            }
            return Ok();
        }
    }
}
