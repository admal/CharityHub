using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CharityHub.Domain.Models.UserModels
{
    public class UserParticipateEventModel
    {
        [Required]
        public int? CharityEventId { get; set; }
        [Required]
        public int? UserId { get; set; }
    }
}
