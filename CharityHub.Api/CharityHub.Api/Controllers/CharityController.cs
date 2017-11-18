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
    [Route("api/Charity")]
    [Produces("application/json")]
    public class CharityController : Controller
    {
        private readonly ICharityService _charityService;

        public CharityController(ICharityService charityService)
        {
            _charityService = charityService;
        }
        
        [HttpGet]
        public IActionResult GetCharities()
        {
            var charities = _charityService.GetCharities();
            return Ok(charities);
        }

        [HttpGet]
        [Route("GetObserved")]
        public IActionResult GetObservedCharities(int userId)
        {
            var charities = _charityService.GetObservedCharities(userId);
            return Json(charities);
        }

        [HttpPost]
        [Route("Observe")]
        public IActionResult ObserveCharity(int userId, int charityId)
        {
            _charityService.ObserveCharity(userId, charityId);
            return Ok();
        }

        [HttpPost]
        [Route("CancelObserve")]
        public IActionResult CancelObserveCharity(int userId, int charityId)
        {
            _charityService.CancelObserveCharity(userId, charityId);
            return Ok();
        }
    }
}