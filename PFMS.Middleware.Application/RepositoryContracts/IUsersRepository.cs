
using PFMS.Middleware.Application.DTO;
using PFMS.Middleware.Domain.Entities;

namespace PFMS.Middleware.Application.RepositoryContracts
{
    public interface IUsersRepository
    {
        Task<PfmsUser?> GetUserInfoBYUserID(int? id);
        Task<RegisteredUser?> AddUser(UserRegisteration registerRequest);
    }
}
