using System.Collections.Generic;
using CharityHub.Domain.Models.Charity;

namespace CharityHub.Services.CharityService
{
    public interface ICharityService
    {
        void AddCharity(CharityAddEditModel model);
        IEnumerable<CharityModel> GetCharities();
        CharityModel GetCharity(int charityId);
    }
}