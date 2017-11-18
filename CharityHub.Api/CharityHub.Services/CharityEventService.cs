using CharityHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CharityHub.Domain.Models.EventModels;
using AutoMapper;
using System.Linq;
using CharityHub.Domain;
using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.CharityEventModels;

namespace CharityHub.Services
{
    public class CharityEventService : ICharityEventService
    {
        private CharityHubContext context;
        private IMapper mapper;

        public CharityEventService(
            CharityHubContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Add(CharityEventInputModel inputModel)
        {
            var charityEvent = mapper.Map<CharityEventInputModel, CharityEvent>(inputModel);

            charityEvent.StartDate = DateTime.Now;

            context.CharityEvents.Add(charityEvent);

            context.SaveChanges();
        }


        public CharityEventModel Get(int id)
        {
            var charityEvent = context.CharityEvents.Find(id);

            if (charityEvent == null)
                return null;

            var charityEventModel = mapper.Map<CharityEvent, CharityEventModel>(charityEvent);

            return charityEventModel;
        }

        public ICollection<CharityEventModel> GetAllForCharity(int charityId)
        {
            ICollection<CharityEvent> charityEvents = (from e in context.CharityEvents
                                                       where e.CharityId == charityId
                                                       select e).ToList();

            var chairtyEventModels = mapper.Map<ICollection<CharityEvent>, ICollection<CharityEventModel>>(charityEvents);

            return chairtyEventModels;
        }

        public ICollection<CharityEventModel> GetAllForUsers(int userId)
        {
            //ICollection<CharityEvent> charityEvents = (from e in context.CharityEvents
            //                                           where e.Participants
            //                                           select e).ToList();

            //var chairtyEventModels = mapper.Map<ICollection<CharityEvent>, ICollection<CharityEventModel>>(charityEvents);

            //return chairtyEventModels;

            return NotImplementedException();
        }
    }
}
