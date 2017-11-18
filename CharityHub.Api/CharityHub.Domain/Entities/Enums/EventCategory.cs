using System.ComponentModel;

namespace CharityHub.Domain.Entities
{
    public enum EventCategory
    {
        [Description("Zbiórka pieniędzy")]
        Fundraising,
        [Description("Zbiórka jedzenia")]
        FoodCollection
    }
}