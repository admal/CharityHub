using CharityHub.Domain.Models.EventModels;
using CharityHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CharityHub.Services
{
    public class EmailNotificationService : IEmailNotificationService
    {
        public void SendEmailEventWasAdded(SendEmailNotificationInputModel inputModel)
        {
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress("GymRegressTeam@gmail.com");
                msg.To.Add(inputModel.EmailAddress);
                msg.IsBodyHtml = true;
                msg.Subject = "Organizacja " + inputModel.OrganizationName + " zorganizowała wydarzenie " + inputModel.EventName;

                using (StreamReader reader = File.OpenText(AppDomain.CurrentDomain.BaseDirectory
                    + @"Assets\EventNotification.html"))
                {
                    string mailText = reader.ReadToEnd()
                        .Replace("_PageUrl_", inputModel.PageUrl)
                        .Replace("_Organization_", inputModel.OrganizationName)
                        .Replace("_EventName_", inputModel.EventName)
                        .Replace("_StartDate_", inputModel.StartDate.ToString(@"MM\/dd\/yyyy HH:mm"))
                        .Replace("_EndDate_", inputModel.EndDate.ToString(@"MM\/dd\/yyyy HH:mm"))    
                        .Replace("_Place_", inputModel.Place);
                    msg.Body = mailText;
                }

                SmtpClient client = GetSmtpClient();

                client.Send(msg);
            }
        }

        private SmtpClient GetSmtpClient()
        {
            return new SmtpClient()
            {
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 20000,
                Credentials = new NetworkCredential("GymRegressTeam@gmail.com", "regres123")
            };
        }
    }
}
