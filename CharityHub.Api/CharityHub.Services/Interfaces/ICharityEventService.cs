using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.EventModels;
using CharityHub.Domain.Models.CharityEventModels;

namespace CharityHub.Services.Interfaces
{
    public interface ICharityEventService
    {
        int Add(CharityEventInputModel inputModel);
        CharityEventModel Get(int id);
        void UserSignInCharityEvent(int userId, int charityEventId);
        void UserSignOutCharityEvent(int userId, int charityEventId);
        void AcceptUser(int userId, int charityEventId);
        void RejectUser(int userId, int charityEventId);
        void AddEventNotification(SendEmailEventNotificationInputModel inputModel);
        IEnumerable<object> GetUserCharityEvents(int userId, bool isSigned);
        IEnumerable<object> GetOrganizationCharityEvents(int charityId, int ownerId);
        IEnumerable<object> GetCharityEvents(string name, int? category);
    }
}
