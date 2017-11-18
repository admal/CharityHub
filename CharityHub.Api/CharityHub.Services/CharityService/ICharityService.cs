using System.Collections.Generic;
using CharityHub.Domain.Models.Charity;
using CharityHub.Domain.Models.UserModels;

namespace CharityHub.Services.CharityService
{
    public interface ICharityService
    {
        void AddCharity(CharityAddEditModel model);
        IEnumerable<CharityModel> GetCharities();
        string GetCharityName(int charityId);
        IEnumerable<UserModel> GetObserved(int charityId);
    }
}