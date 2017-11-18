using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.Charity;
using CharityHub.Domain.Models.EventParticipantModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain.Models.CharityEventModels
{
    public class CharityEventModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CharityId { get; set; }
        public EventCategory EventCategory { get; set; }
        public ICollection<EventParticipantModel> Participants { get; set; }
        //public ICollection<EventNotification> Notifications { get; set; }
    }
}
