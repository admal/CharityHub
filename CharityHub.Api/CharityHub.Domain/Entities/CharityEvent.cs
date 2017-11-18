using System;
using System.Collections.Generic;

namespace CharityHub.Domain.Entities
{
    public class CharityEvent : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }

        public virtual int CharityId { get; set; }
        public virtual Charity Charity { get; set; }

        public virtual EventCategory EventCategory { get; set; }

        public virtual ICollection<EventParticipant> Participants { get; set; }
        public virtual ICollection<EventNotification> Notifications { get; set; }
    }
}