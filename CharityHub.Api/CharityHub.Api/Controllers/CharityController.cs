﻿using System;
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

        [HttpPost]
        public IActionResult AddCharity([FromBody] CharityModel model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            _charityService.AddCharity(model);
            return Ok();
        }

    }
}