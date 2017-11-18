using System.Collections.Generic;
using CharityHub.Domain.Models.Charity;

namespace CharityHub.Services.CharityService
{
    public interface ICharityService
    {
        void AddCharity(CharityAddEditModel model);
        IEnumerable<CharityModel> GetCharities(int? userId, string name, int? category);
        CharityModel GetCharity(int charityId);
        void ObserveCharity(int userId, int charityId);
        void CancelObserveCharity(int userId, int charityId);
        IEnumerable<CharityModel> GetObservedCharities(int userId);
    }
}