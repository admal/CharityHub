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

            var user = _context.Users.First(x => x.Id == model.OwnerId);
            user.Charity = newCharity;
            _context.SaveChanges();
        }

        public string GetCharityName(int charityId)
        {
            return _context.Charities
                .Where(x => x.Id == charityId)
               .Select(x => x.Owner.Name).SingleOrDefault();
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