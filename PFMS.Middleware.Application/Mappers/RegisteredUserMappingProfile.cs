using AutoMapper;
using PFMS.Middleware.Application.DTO;
using PFMS.Middleware.Domain.Entities;

namespace PFMS.Middleware.Application.Mappers
{
    public class RegisteredUserMappingProfile : Profile
    {
        public RegisteredUserMappingProfile() 
        {
            // Map Entity -> Record (Fixes the mapping error)
            CreateMap<RegisteredUser, RegisteredUserResponse>()
                .ForCtorParam("Message", opt => opt.MapFrom(src => src.Message ?? string.Empty))
                .ForCtorParam("Success", opt => opt.MapFrom(src => src.Success ?? false));         
        }
    }
}
