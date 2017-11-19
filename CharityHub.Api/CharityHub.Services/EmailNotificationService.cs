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
        public void SendEmailEventNotification(SendEmailEventNotificationModel inputModel)
        {
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress("GymRegressTeam@gmail.com");
                msg.To.Add(inputModel.EmailAddress);
                msg.IsBodyHtml = true;
                msg.Subject = inputModel.CharityName + " dodała wiadomość w wydarzeniu " + inputModel.CharityEventName;

                using (StreamReader reader = File.OpenText(AppDomain.CurrentDomain.BaseDirectory
                    + @"Assets/EventNotification.html"))
                {
                    string mailText = reader.ReadToEnd()
                        .Replace("_Content_", inputModel.Content)
                        .Replace("_Subject_", inputModel.Subject);
                    msg.Body = mailText;
                }

                SmtpClient client = GetSmtpClient();

                client.Send(msg);
            }
        }

        public void SendEmailEventWasAdded(SendEmailEventWasAddedModel inputModel)
        {
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress("GymRegressTeam@gmail.com");
                msg.To.Add(inputModel.EmailAddress);
                msg.IsBodyHtml = true;
                msg.Subject = inputModel.CharityName + " zorganizowała wydarzenie " + inputModel.CharityEventName;

                using (StreamReader reader = File.OpenText(AppDomain.CurrentDomain.BaseDirectory
                    + @"Assets/EventWasAdded.html"))
                {
                    string mailText = reader.ReadToEnd()
                        .Replace("_Organization_", inputModel.CharityName)
                        .Replace("_EventName_", inputModel.CharityEventName)
                        .Replace("_StartDate_", inputModel.StartDate.ToString(@"MM\/dd\/yyyy"))
                        .Replace("_EndDate_", inputModel.EndDate.ToString(@"MM\/dd\/yyyy")); 
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
