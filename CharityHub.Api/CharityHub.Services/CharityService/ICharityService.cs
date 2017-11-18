using System.Collections.Generic;
using CharityHub.Domain.Models.Charity;
using CharityHub.Domain.Models.UserModels;

namespace CharityHub.Services.CharityService
{
    public interface ICharityService
    {
        void AddCharity(CharityAddEditModel model);
        IEnumerable<CharityModel> GetCharities(int? userId, string name, int? category);
        string GetCharityName(int charityId);
        CharityModel GetCharity(int id);
        IEnumerable<UserModel> GetObserved(int charityId);
        void ObserveCharity(int userId, int charityId);
        void CancelObserveCharity(int userId, int charityId);
        IEnumerable<CharityModel> GetObservedCharities(int userId);
    }
}