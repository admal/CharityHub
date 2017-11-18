using System;
using System.Collections.Generic;
using System.Linq;
using CharityHub.Domain;
using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.Charity;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<CharityModel> GetObservedCharities(int userId)
        {
            var charities = _context.Users
                .Where(x => x.Id == userId)
                .Include(x => x.ObservedCharities)
                .SelectMany(x => x.ObservedCharities)
                .Include(x => x.Charity)
                .Select(x => x.Charity)
                .Include(x => x.Owner)
                .Select(x => new CharityModel()
                {
                    Id = x.Id,
                    OwnerId = x.OwnerId,
                    Description = x.Description,
                    Name = x.Name,
                    Category = (int) x.Category,
                    OwnerName = x.Owner.Name
                })
                .ToList();
            return charities;
        }

        public void ObserveCharity(int userId, int charityId)
        {
            var exists = _context.Users_Charities.Any(x => x.UserId == userId && x.CharityId == charityId);
            if (exists)
            {
                return;
            }

            var observedCharity = new User_Charity()
            {
                CharityId = charityId,
                UserId = userId
            };
            _context.Users_Charities.Add(observedCharity);
            _context.SaveChanges();
        }

        public void CancelObserveCharity(int userId, int charityId)
        {
            var exists = _context.Users_Charities.Any(x => x.UserId == userId && x.CharityId == charityId);
            if (exists == false)
            {
                return;
            }

            var observedCharity = _context.Users_Charities.First(x => x.UserId == userId && x.CharityId == charityId);
            _context.Users_Charities.Remove(observedCharity);
            _context.SaveChanges();
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

            var user = _context.Users.First(x => x.Id == model.OwnerId);
            user.Charity = newCharity;
            _context.SaveChanges();
        }

        public CharityModel GetCharity(int charityId)
        {
            return _context.Charities
                .Where(x => x.Id == charityId)
               .Select(x => new CharityModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
                   OwnerId = x.OwnerId,
                   Category = (int)x.Category,
                   OwnerName = x.Owner.Name
               }).SingleOrDefault();
        }
    }
}