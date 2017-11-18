using AutoMapper;
using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.CharityEventModels;
using CharityHub.Domain.Models.EventModels;
using CharityHub.Domain.Models.UserModels;
using CharityHub.Services.Interfaces;

namespace CharityHub.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile(ICryptographyService cryptographyService)
        {
            CreateMap<User, UserModel>();
            CreateMap<CharityEventInputModel, CharityEvent>();
            CreateMap<CharityEvent, CharityEventModel>();
            CreateMap<SignUpInputModel, User>()
                .ForMember(dest => dest.PasswordHash, e => e.MapFrom(src => cryptographyService.GetHashString(src.Password)));
        }
    }
}
