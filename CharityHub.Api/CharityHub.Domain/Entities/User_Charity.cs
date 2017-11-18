namespace CharityHub.Domain.Entities
{
    public class User_Charity : Entity
    {
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual int CharityId { get; set; }
        public virtual Charity Charity { get; set; }
    }
}