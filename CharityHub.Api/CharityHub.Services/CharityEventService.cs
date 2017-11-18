﻿using CharityHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CharityHub.Domain.Models.EventModels;
using AutoMapper;
using System.Linq;
using CharityHub.Domain;
using Microsoft.EntityFrameworkCore;
using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.CharityEventModels;
using CharityHub.Domain.Models.EventParticipantModels;


namespace CharityHub.Services
{
    public class CharityEventService : ICharityEventService
    {
        private readonly CharityHubContext _context;
        private readonly IMapper _mapper;

        public CharityEventService(
            CharityHubContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Add(CharityEventInputModel inputModel)
        {
            var charityEvent = _mapper.Map<CharityEventInputModel, CharityEvent>(inputModel);

            charityEvent.StartDate = DateTime.Now;

            _context.CharityEvents.Add(charityEvent);

            _context.SaveChanges();
        }

        public IEnumerable<object> GetCharityEvents(string name, int? eventCategory)
        {
            var events = _context.CharityEvents
                .Where(x => name == null || name == "" || x.Name.Contains(name))
                .Where(x => eventCategory == null || x.EventCategory == (EventCategory)eventCategory.Value)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    CharityId = x.CharityId,
                    EventCategory = x.EventCategory
                })
                .ToList();
            return events;
        }

        public IEnumerable<object> GetUserCharityEvents(int userId, bool isSigned)
        {
            var events = _context.Users
                .Include(x => x.Events)
                .Where(x => x.Id == userId)
                .SelectMany(x => x.Events)
                .Where(x => (isSigned == false && x.IsAccepted == null) || (isSigned && x.IsAccepted.Value))
                .Include(x => x.CharityEvent)
                .Select(x => x.CharityEvent)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    CharityId = x.CharityId,
                    EventCategory = x.EventCategory
                })
                .ToList();
            return events;
        }

        public IEnumerable<object> GetOrganizationCharityEvents(int charityId, int ownerId)
        {
            var events = _context.Users
                .Include(x => x.Events)
                .Where(x => x.CharityId == charityId && x.Id == ownerId)
                .SelectMany(x => x.Events)
                .Include(x => x.CharityEvent)
                .Select(x => x.CharityEvent)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    CharityId = x.CharityId,
                    EventCategory = x.EventCategory
                })
                .ToList();
            return events;
        }

        public CharityEventModel Get(int id)
        {
            var charityEvent = _context.CharityEvents.Find(id);

            if (charityEvent == null)
                return null;

            var charityEventModel = _mapper.Map<CharityEvent, CharityEventModel>(charityEvent);

            ICollection<EventParticipant> participants = (from p in _context.EventParticipants
                                                          where p.CharityEventId == id
                                                          select p)
                                                          .Include(x => x.User)
                                                          .ToList(); 

            charityEventModel.Participants = _mapper.Map<ICollection<EventParticipant>, ICollection<EventParticipantModel>>(participants);

            return charityEventModel;
        }

        public ICollection<CharityEventModel> GetAllForCharity(int charityId)
        {
            ICollection<CharityEvent> charityEvents = (from e in _context.CharityEvents
                                                       where e.CharityId == charityId
                                                       select e).ToList();

            var chairtyEventModels = _mapper.Map<ICollection<CharityEvent>, ICollection<CharityEventModel>>(charityEvents);

            return chairtyEventModels;
        }

        public ICollection<CharityEventModel> GetAllForUsers(int userId)
        {
            //ICollection<CharityEvent> charityEvents = (from e in context.CharityEvents
            //                                           where e.Participants
            //                                           select e).ToList();

            //var chairtyEventModels = mapper.Map<ICollection<CharityEvent>, ICollection<CharityEventModel>>(charityEvents);

            //return chairtyEventModels;

            throw new NotImplementedException();
        }

        public void UserSignInCharityEvent(int userId, int charityEventId)
        {
            var exists = _context.EventParticipants.Any(x => x.UserId == userId && x.CharityEventId == charityEventId);
            if (exists)
            {
                return;
            }

            var newParticipant = new EventParticipant()
            {
                IsAccepted = null,
                ParticipationRequestDate = DateTime.Now,
                UserId = userId,
                CharityEventId = charityEventId
            };
            _context.EventParticipants.Add(newParticipant);
            _context.SaveChanges();
        }

        public void UserSignOutCharityEvent(int userId, int charityEventId)
        {
            var exists = _context.EventParticipants.Any(x => x.UserId == userId && x.CharityEventId == charityEventId);
            if (exists == false)
            {
                return;
            }
            
            var participant = _context.EventParticipants.First(x => x.UserId == userId && x.CharityEventId == charityEventId);
            _context.EventParticipants.Remove(participant);
            _context.SaveChanges();
        }

        public void AcceptUser(int userId, int charityEventId)
        {
            var exists = _context.EventParticipants.Any(x => x.UserId == userId && x.CharityEventId == charityEventId);
            if (exists == false)
            {
                return;
            }

            var participant = _context.EventParticipants.First(x => x.UserId == userId && x.CharityEventId == charityEventId);
            participant.IsAccepted = true;
            _context.SaveChanges();
        }

        public void RejectUser(int userId, int charityEventId)
        {
            var exists = _context.EventParticipants.Any(x => x.UserId == userId && x.CharityEventId == charityEventId);
            if (exists == false)
            {
                return;
            }

            var participant = _context.EventParticipants.First(x => x.UserId == userId && x.CharityEventId == charityEventId);
            participant.IsAccepted = false;
            _context.SaveChanges();
        }
    }
}
