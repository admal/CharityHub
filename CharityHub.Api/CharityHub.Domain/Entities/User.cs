using CharityHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain.Entities
{
    public class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual Sex Sex { get; set; }


        public virtual long? CharityId { get; set; }
        public virtual Charity Charity { get; set; }

        public virtual ICollection<User_Charity> ObservedCharities { get; set; }
        public virtual ICollection<EventParticipant> Events { get; set; }
    }
}