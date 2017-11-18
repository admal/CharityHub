using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain.Models.EventModels
{
    public class CharityEventInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CharityId { get; set; }
        public int EventCategory { get; set; }
    }
}
