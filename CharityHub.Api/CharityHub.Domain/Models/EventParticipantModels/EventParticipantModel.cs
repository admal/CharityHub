using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain.Models.EventParticipantModels
{
    public class EventParticipantModel
    {
        public DateTime ParticipationRequestDate { get; set; }
        public bool? IsAccepted { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
