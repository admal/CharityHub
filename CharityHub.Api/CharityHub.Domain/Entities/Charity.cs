using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityHub.Domain.Entities
{
    public class Charity : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual CharityCategory Category { get; set; }

        [ForeignKey("UserId")]
        public virtual User Owner { get; set; }
        public virtual int OwnerId { get; set; }

        public virtual ICollection<CharityEvent> Events { get; set; }
        public virtual ICollection<User_Charity> ObservedByUsers { get; set; }
    }
}