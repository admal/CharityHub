using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityHub.Domain.Models.EventModels;
using CharityHub.Services.CharityService;
using CharityHub.Services.EventNotificationService;
using CharityHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityHub.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/EventNotification")]
    public class EventNotificationController : Controller
    {
        private readonly IEventNotificationQueryService _eventNotificationQueryService;
        private readonly IEmailNotificationService _emailNotificationService;
        private readonly ICharityEventService _charityEventService;
        private readonly IUserService _userService;
        private readonly ICharityService _charityService;

        public EventNotificationController(IEventNotificationQueryService eventNotificationQueryService, 
            IEmailNotificationService emailNotificationService, 
            ICharityEventService charityEventService, 
            IUserService userService, 
            ICharityService charityService)
        {
            _eventNotificationQueryService = eventNotificationQueryService;
            _emailNotificationService = emailNotificationService;
            _charityEventService = charityEventService;
            _userService = userService;
            _charityService = charityService;
        }

        [HttpGet]
        [Route("GetUserNotifications")]
        public IActionResult GetUserNotifications(int userId)
        {
            var notifications = _eventNotificationQueryService.GetUserNotifications(userId);
            return Json(notifications);
        }


        [HttpPost]
        [Route("AddEmailEventNotification")]
        public IActionResult AddEmailEventNotification([FromBody]SendEmailEventNotificationInputModel inputModel)
        {
            var charityEvent = _charityEventService.Get(inputModel.CharityEventId);
            string charityName = _charityService.GetCharityName(charityEvent.CharityId);

            foreach (var p in charityEvent.Participants)
            {
                if (p.IsAccepted != true)
                {
                    continue;
                }

                var user = _userService.GetUser(p.UserId);

                var sendEmailEventWasAddedModel = new SendEmailEventNotificationModel()
                {
                    EmailAddress = user.EmailAddress,
                    Content = inputModel.Content,
                    CharityEventName = charityEvent.Name,
                    CharityName = charityName,
                    Subject = inputModel.Subject
                };

                _emailNotificationService.SendEmailEventNotification(sendEmailEventWasAddedModel);
            }

            _charityEventService.AddEventNotification(inputModel);

            return Ok();
        }
    }
}