using System.Collections.Generic;
using CharityHub.Domain.Models.Charity;

namespace CharityHub.Services.CharityService
{
    public interface ICharityService
    {
        void AddCharity(CharityModel model);
        IEnumerable<CharityModel> GetCharities();
    }
}