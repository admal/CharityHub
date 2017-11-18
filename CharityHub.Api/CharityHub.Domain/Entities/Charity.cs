using System;
using System.Collections.Generic;

namespace CharityHub.Domain.Entities
{
    public class Charity : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual CharityCategory Category { get; set; }

        public virtual User Owner { get; set; }
        public virtual long  OwnerId { get; set; }

        public virtual ICollection<CharityEvent> Events { get; set; }
        public virtual ICollection<User_Charity> ObservedByUsers { get; set; }
    }
}