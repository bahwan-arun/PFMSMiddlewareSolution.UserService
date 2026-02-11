using AutoMapper;
using PFMS.Middleware.Application.DTO;
using PFMS.Middleware.Domain.Entities;


namespace PFMS.Middleware.Application.Mappers
{
    public class UserRegisterationMappingProfile: Profile
    {
        public UserRegisterationMappingProfile()
        {
            CreateMap<RegisterUserRequest, UserRegisteration>();
        }
    }
}
