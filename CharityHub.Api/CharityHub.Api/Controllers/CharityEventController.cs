using CharityHub.Domain.Models.EventModels;
using CharityHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityHub.Domain.Models.UserModels;
using CharityHub.Services.CharityService;

namespace CharityHub.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CharityEventController : Controller
    {
        private IEmailNotificationService emailNotificationService;
        private ICharityEventService charityEventService;
        private IUserService userService;
        private ICharityService charityService;

        public CharityEventController(
            IEmailNotificationService emailNotificationService,
            ICharityEventService charityEventService,
            IUserService userService,
            ICharityService charityService)
        {
            this.emailNotificationService = emailNotificationService;
            this.charityEventService = charityEventService;
            this.userService = userService;
            this.charityService = charityService;
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
        [Route("GetEvents")]
        public IActionResult GetCharityEvents(string name, int? category)
        {
            var events = charityEventService.GetCharityEvents(name, category);
            return Json(events);
        }

        [HttpGet]
        [Route("GetEventsForUser")]
        public IActionResult GetUserCharityEventsForUser(int userId, bool isSigned)
        {
            var events = charityEventService.GetUserCharityEvents(userId, isSigned);
            return Json(events);
        }

        [HttpGet]
        [Route("GetEventsForCharity")]
        public IActionResult GetUserCharityEventsForCharity(int charityId, int ownerId)
        {
            var events = charityEventService.GetOrganizationCharityEvents(charityId, ownerId);
            return Json(events);
        }

        [HttpPost]
        public IActionResult Add([FromBody]CharityEventInputModel inputModel)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            int id = charityEventService.Add(inputModel);

            SendEmailEventWasAdded(id);

            return Ok();
        }

        [HttpPost]
        [Route("SendEmailEventNotification")]
        public IActionResult SendEmailEventNotification([FromBody]SendEmailEventNotificationInputModel inputModel)
        {
            var charityEvent = charityEventService.Get(inputModel.CharityEventId);
            string charityName = charityService.GetCharityName(charityEvent.CharityId);

            foreach (var p in charityEvent.Participants)
            {
                if (p.IsAccepted != true)
                {
                    continue;
                }

                var user = userService.GetUser(p.UserId);

                var sendEmailEventWasAddedModel = new SendEmailEventNotificationModel()
                {
                    EmailAddress = user.EmailAddress,
                    Content = inputModel.Content,
                    CharityEventName = charityEvent.Name,
                    CharityName = charityName,
                    Subject = inputModel.Subject
                };

                emailNotificationService.SendEmailEventNotification(sendEmailEventWasAddedModel);
            }

            charityEventService.AddEventNotification(inputModel);

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

        private void SendEmailEventWasAdded(int id)
        {
            var charityEvent = charityEventService.Get(id);
            string charityName = charityService.GetCharityName(charityEvent.CharityId);
            var users = charityService.GetObserved(charityEvent.CharityId);

            foreach (var u in users)
            {
                var inputModel = new SendEmailEventWasAddedModel()
                {
                    EndDate = charityEvent.EndDate,
                    StartDate = charityEvent.StartDate,
                    CharityEventName = charityEvent.Name,
                    EmailAddress = u.EmailAddress,
                    CharityName = charityName
                };

                emailNotificationService.SendEmailEventWasAdded(inputModel);
            }
        }
    }
}
