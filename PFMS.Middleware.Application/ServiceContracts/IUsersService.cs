using PFMS.Middleware.Application.DTO;
using PFMS.Middleware.Domain.Entities;


namespace PFMS.Middleware.Application.ServiceContracts
{
    public interface IUsersService
    {
        Task<PfmsUser?> GetUser(int? id);
        Task<RegisteredUserResponse?> Register(RegisterUserRequest registerRequest);
    }
}
