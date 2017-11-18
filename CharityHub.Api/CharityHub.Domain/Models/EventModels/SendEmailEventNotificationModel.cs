using System;
using System.ComponentModel.DataAnnotations;

namespace CharityHub.Domain.Models.EventModels
{
    public class SendEmailEventNotificationModel
    {
        public string EmailAddress { get; set; }
        public string Content { get; set; }
        public string CharityName { get; set; }
        public string CharityEventName { get; set; }
        public string Subject { get; set; }
    }
}
