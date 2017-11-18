using System;

namespace CharityHub.Domain.Entities
{
    public class EventParticipant : Entity
    {
        public virtual DateTime ParticipationRequestDate { get; set; }
        public virtual bool? IsAccepted { get; set; }

        public virtual int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual int CharityEventId { get; set; }
        public virtual CharityEvent CharityEvent { get; set; }
    }
}