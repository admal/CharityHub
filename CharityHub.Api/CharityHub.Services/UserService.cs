using CharityHub.Domain;
using CharityHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Services
{
    public class UserService : IUserService
    {
        private CharityHubContext context;

        public UserService(CharityHubContext context)
        {
            this.context = context;
        }

        public string Test()
        {
            return context.Users.Find(1).Name;
        }
    }
}
