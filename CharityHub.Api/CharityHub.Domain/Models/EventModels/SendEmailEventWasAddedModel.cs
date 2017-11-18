using System;
using System.ComponentModel.DataAnnotations;

namespace CharityHub.Domain.Models.EventModels
{
    public class SendEmailEventWasAddedModel
    {
        public string EmailAddress { get; set; }
        public string CharityName { get; set; }
        public string CharityEventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
