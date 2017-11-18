using System;
using System.Collections.Generic;
using System.Linq;
using CharityHub.Domain;
using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.Charity;

namespace CharityHub.Services.CharityService
{
    public class CharityService : ICharityService
    {
        private readonly CharityHubContext _context;

        public CharityService(CharityHubContext context)
        {
            _context = context;
        }

        public IEnumerable<CharityModel> GetCharities()
        {
            var charities = _context.Charities
                .Select(x => new CharityModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    OwnerId = x.OwnerId,
                    Category = (int)x.Category,
                    OwnerName = x.Owner.Name
                });
            return charities;
        }

        public void AddCharity(CharityAddEditModel model)
        {
            var newCharity = new Charity();
            newCharity.Name = model.Name;
            newCharity.Description = model.Description;
            newCharity.Category = (CharityCategory)model.Category;
            newCharity.CreatedDate = DateTime.Now;
            newCharity.Owner = _context.Users.First(x => x.Id == model.OwnerId);
            newCharity.OwnerId = model.OwnerId;

            _context.Charities.Add(newCharity);
            _context.SaveChanges();
        }
    }
}