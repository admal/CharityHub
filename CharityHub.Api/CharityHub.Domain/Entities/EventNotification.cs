using System;

namespace CharityHub.Domain.Entities
{
    public class EventNotification : Entity
    {
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime CreatedDate { get; set; }

        public virtual int EventId { get; set; }
        public virtual CharityEvent CharityEvent { get; set; }
    }
}