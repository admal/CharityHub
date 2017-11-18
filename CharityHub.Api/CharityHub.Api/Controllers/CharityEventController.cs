using CharityHub.Domain.Models.EventModels;
using CharityHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityHub.Domain.Models.UserModels;

namespace CharityHub.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CharityEventController : Controller
    {
        private IEmailNotificationService emailNotificationService;
        private ICharityEventService charityEventService;

        public CharityEventController(
            IEmailNotificationService emailNotificationService,
            ICharityEventService charityEventService)
        {
            this.emailNotificationService = emailNotificationService;
            this.charityEventService = charityEventService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var charityEvent = charityEventService.Get(id);

            if(charityEvent == null)
            {
                return NotFound();
            }

            return Ok(charityEvent);
        }

        [HttpGet]
        [Route("GetUserEvents")]
        public IActionResult GetUserEvents(int userId)
        {
            var charityEvents = charityEventService.GetAllForUsers(userId);

            if (charityEvents == null)
            {
                return NotFound();
            }

            return Ok(charityEvents);
        }

        [HttpGet]
        [Route("GetCharityEvents")]
        public IActionResult GetCharityEvents(int charityId)
        {
            var charityEvents = charityEventService.GetAllForCharity(charityId);

            if (charityEvents == null)
            {
                return NotFound();
            }

            return Ok(charityEvents);
        }

        [HttpPost]
        public IActionResult Add([FromBody]CharityEventInputModel inputModel)
        {
            charityEventService.Add(inputModel);

            return Ok();
        }

        /// <summary>
        /// TODO: Zmienić na tylko eventId
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SendEmailNotification")]
        public IActionResult SendEmailNotification([FromBody]SendEmailNotificationInputModel inputModel)
        {
            emailNotificationService.SendEmailEventWasAdded(inputModel);

            return Ok();
        }

        [HttpPost]
        [Route("SignInEvent")]
        public IActionResult SignInCharityEvent(UserParticipateEventModel model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            charityEventService.UserSignInCharityEvent(model.UserId.Value, model.CharityEventId.Value);
            return Ok();
        }

        [HttpPost]
        [Route("SignOutEvent")]
        public IActionResult SignOutCharityEvent(UserParticipateEventModel model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            charityEventService.UserSignOutCharityEvent(model.UserId.Value, model.CharityEventId.Value);
            return Ok();
        }

        [HttpPost]
        [Route("AcceptUser")]
        public IActionResult AcceptUserInCharityEvent(UserParticipateEventModel model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            charityEventService.AcceptUser(model.UserId.Value, model.CharityEventId.Value);
            return Ok();
        }

        [HttpPost]
        [Route("RejectUser")]
        public IActionResult RejectUserInCharityEvent(UserParticipateEventModel model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            charityEventService.RejectUser(model.UserId.Value, model.CharityEventId.Value);
            return Ok();
        }
    }
}
