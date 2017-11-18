using System;

namespace CharityHub.Domain.Models
{
    public class EventNotificationModel
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string EventName { get; set; }
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// Nowy event organizacji, która event obserwuje
        /// </summary>
        public bool IsNew { get; set; }
    }
}