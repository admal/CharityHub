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

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok(userService.Test());
        }
    }
}
