using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityHub.Domain.Models.Charity;
using CharityHub.Services.CharityService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityHub.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Charity")]
    public class CharityController : Controller
    {
        private readonly ICharityService _charityService;

        public CharityController(ICharityService charityService)
        {
            _charityService = charityService;
        }
        
        [HttpGet]
        [Route("Get")]
        public IActionResult GetCharities()
        {
            var charities = _charityService.GetCharities();
            return Json(charities);
        }

        [HttpPost]
        public IActionResult AddCharity([FromBody] CharityModel model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            _charityService.AddCharity(model);
            return Ok();
        }

    }
}