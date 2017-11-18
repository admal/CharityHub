using CharityHub.Domain;
using CharityHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CharityHub.Domain.Models.UserModels;
using AutoMapper;
using CharityHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharityHub.Services
{
    public class UserService : IUserService
    {
        private CharityHubContext context;
        private readonly IMapper mapper;

        public UserService(CharityHubContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public User Add(SignUpInputModel inputModel)
        {
            if (Exists(inputModel.EmailAddress))
            {
                return null;
            }

            var user = mapper.Map<SignUpInputModel, User>(inputModel);

            context.Users.Add(user);

            context.SaveChanges();

            return user;
        }

        public UserModel GetUser(int id)
        {
            var user = (from u in context.Users
                        where u.Id == id
                        select u)
                        .Include(x => x.Charity)
                        .Include(x => x.ObservedCharities)
                        .Include(x => x.Events)
                        .SingleOrDefault();

            var userModel = mapper.Map<User, UserModel>(user);

            return userModel;
        }

        public UserModel GetUser(string login, string passwordHash)
        {
            var user = (from u in context.Users
                        where u.EmailAddress == login && u.PasswordHash == passwordHash
                        select u).SingleOrDefault();
            return GetUser(user.Id);
        }

        private bool Exists(string emailAddress)
        {
            return (from u in context.Users
                    where u.EmailAddress == emailAddress
                    select u).Count() > 0;
        }
    }
}
