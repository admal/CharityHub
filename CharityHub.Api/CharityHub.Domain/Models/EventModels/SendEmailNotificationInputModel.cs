using System;
using System.ComponentModel.DataAnnotations;

namespace CharityHub.Domain.Models.EventModels
{
    public class SendEmailNotificationInputModel
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string OrganizationName { get; set; }
        public string EventName { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PageUrl { get; set; }
    }
}
