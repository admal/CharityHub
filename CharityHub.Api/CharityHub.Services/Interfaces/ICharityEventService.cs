﻿using System;
using System.Collections.Generic;
using System.Text;
using CharityHub.Domain.Models.EventModels;
using CharityHub.Domain.Models.CharityEventModels;

namespace CharityHub.Services.Interfaces
{
    public interface ICharityEventService
    {
        void Add(CharityEventInputModel inputModel);
        CharityEventModel Get(int id);
        ICollection<CharityEventModel> GetAllForCharity(int charityId);
        ICollection<CharityEventModel> GetAllForUsers(int userId);
    }
}