using AutoMapper;
using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.CharityEventModels;
using CharityHub.Domain.Models.EventModels;
using CharityHub.Domain.Models.EventParticipantModels;
using CharityHub.Domain.Models.UserModels;
using CharityHub.Services.Interfaces;

namespace CharityHub.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile(ICryptographyService cryptographyService)
        {
            CreateMap<User, UserModel>().ForMember(dest => dest.OrganizationId, e => e.MapFrom(src => src.CharityId));
            CreateMap<CharityEventInputModel, CharityEvent>();
            CreateMap<CharityEvent, CharityEventModel>();
            CreateMap<SignUpInputModel, User>()
                .ForMember(dest => dest.PasswordHash, e => e.MapFrom(src => cryptographyService.GetHashString(src.Password)));
            CreateMap<EventParticipant, EventParticipantModel>()
                .ForMember(dest => dest.Surname, e => e.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Name, e => e.MapFrom(src => src.User.Surname));
        }
    }
}
