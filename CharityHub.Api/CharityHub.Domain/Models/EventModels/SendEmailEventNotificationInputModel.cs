using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain.Models.EventModels
{
    public class SendEmailEventNotificationInputModel
    {
        public int CharityEventId { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
    }
}
