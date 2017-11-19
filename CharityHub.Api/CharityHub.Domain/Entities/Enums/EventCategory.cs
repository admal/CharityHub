using System.ComponentModel;

namespace CharityHub.Domain.Entities
{
    public enum EventCategory
    {
        [Description("Pomoc w szpitalach")]
        HospitalHelp,
        [Description("Zwierzęta")]
        Animals,
        [Description("Pomoc bezdomnym")]
        HomelessHelp
    }
}