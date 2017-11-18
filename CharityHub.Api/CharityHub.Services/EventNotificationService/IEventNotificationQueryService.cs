using System.Collections.Generic;
using CharityHub.Domain.Models;

namespace CharityHub.Services.EventNotificationService
{
    public interface IEventNotificationQueryService
    {
        IEnumerable<EventNotificationModel> GetUserNotifications(int userId);
    }
}