using AutoMapper;
using CharityHub.Domain.Entities;
using CharityHub.Domain.Models.UserModels;
using CharityHub.Services.Interfaces;

namespace CharityHub.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile(ICryptographyService cryptographyService)
        {
            CreateMap<User, UserModel>().ForMember(dest => dest.OrganizationId, e => e.MapFrom(src => src.CharityId));
            CreateMap<SignUpInputModel, User>()
                .ForMember(dest => dest.PasswordHash, e => e.MapFrom(src => cryptographyService.GetHashString(src.Password)));
        }
    }
}
