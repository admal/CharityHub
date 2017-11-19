using System;
using System.Collections.Generic;
using System.Linq;
using CharityHub.Domain;
using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.Charity;
using Microsoft.EntityFrameworkCore;
using CharityHub.Domain.Models.UserModels;
using CharityHub.Services.Interfaces;
using AutoMapper;

namespace CharityHub.Services.CharityService
{
    public class CharityService : ICharityService
    {
        private readonly CharityHubContext _context;
        private IUserService userService;
        private IMapper mapper;

        public CharityService(
            CharityHubContext context,
            IUserService userService,
            IMapper mapper)
        {
            _context = context;
            this.userService = userService;
            this.mapper = mapper;
        }

        public IEnumerable<CharityModel> GetCharities(int? userId, string name, int? category)
        {
            var charities = _context.Charities
                .Where(x => name == null || name == "" || x.Name.Contains(name))
                .Where(x => category == null || x.Category == (CharityCategory)category)
                .Select(x => new CharityModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    OwnerId = x.OwnerId,
                    OrganizationType = (int)x.Category,
                    OwnerName = x.Owner.Name,
                    IsObserving = userId != null && x.ObservedByUsers.Any(z => z.UserId == userId.Value)
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
                    OrganizationType = (int)x.Category,
                    OwnerName = x.Owner.Name,
                    IsObserving = x.ObservedByUsers.Select(y => y.Id).Contains(x.Id)
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

        public string GetCharityName(int charityId)
        {
            return _context.Charities
                .Where(x => x.Id == charityId)
                .Select(x => x.Name).SingleOrDefault();
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
                   OrganizationType = (int)x.Category,
                   OwnerName = x.Owner.Name
               }).SingleOrDefault();
        }

        public IEnumerable<UserModel> GetObserved(int charityId)
        {
            var charity = _context.Charities
                .Where(x => x.Id == charityId)
                .Include(x => x.ObservedByUsers)
                .Select(x => x)
                .SingleOrDefault();

            var users = new List<UserModel>();

            foreach(var o in charity.ObservedByUsers)
            {
                users.Add(userService.GetUser(o.UserId));
            }

            return users;
        }
    }
}