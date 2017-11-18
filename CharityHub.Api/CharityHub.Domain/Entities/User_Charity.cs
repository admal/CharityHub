namespace CharityHub.Domain.Entities
{
    public class User_Charity : Entity
    {
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }

        public virtual long CharityId { get; set; }
        public virtual Charity Charity { get; set; }
    }
}