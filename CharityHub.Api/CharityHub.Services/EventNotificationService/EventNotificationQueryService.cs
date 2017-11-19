using System.Collections.Generic;
using System.Linq;
using CharityHub.Domain;
using CharityHub.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CharityHub.Services.EventNotificationService
{
    public class EventNotificationQueryService : IEventNotificationQueryService
    {
        private readonly CharityHubContext _context;

        public EventNotificationQueryService(CharityHubContext context)
        {
            _context = context;
        }

        public IEnumerable<EventNotificationModel> GetUserNotifications(int userId)
        {
            var notifications = _context.EventNotifications
                .Include(x => x.CharityEvent)
                .Include(x => x.CharityEvent.Charity)
                .Include(x => x.CharityEvent.Participants)
                .Where(x =>
                    x.CharityEvent.Participants.Where(y => y.IsAccepted == true && y.UserId == userId).Count() > 0
                )
                .Select(x => new EventNotificationModel()
                {
                    Id = x.Id,
                    OrganizationName = x.CharityEvent.Charity.Name,
                    Date = x.CreatedDate,
                    EventId = x.CharityEventId,
                    EventName = x.CharityEvent.Name,
                    Message = x.Body,
                    Subject = x.Subject
                })
                .ToList();

            return notifications;
        }
    }
}