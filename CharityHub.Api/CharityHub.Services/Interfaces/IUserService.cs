using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Services.Interfaces
{
    public interface IUserService
    {
        UserModel GetUser(int id);
        User GetUser(string login, string passwordHash);
        User Add(SignUpInputModel inputModel);
    }
}
