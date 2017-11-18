using CharityHub.Domain.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Services.Interfaces
{
    public interface IEmailNotificationService
    {
        void SendEmailEventWasAdded(SendEmailNotificationInputModel emailAddress);
    }
}
