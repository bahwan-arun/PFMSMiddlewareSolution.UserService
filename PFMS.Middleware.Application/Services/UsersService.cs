
using AutoMapper;
using PFMS.Middleware.Application.DTO;
using PFMS.Middleware.Application.RepositoryContracts;
using PFMS.Middleware.Application.ServiceContracts;
using PFMS.Middleware.Domain.Entities;

namespace PFMS.Middleware.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<PfmsUser?> GetUser(int? id)
        {
            PfmsUser? user = await _usersRepository.GetUserInfoBYUserID(id);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<RegisteredUserResponse?> Register(RegisterUserRequest registerRequest)
        {
         
            UserRegisteration user = _mapper.Map<UserRegisteration>(registerRequest);
            RegisteredUser? registeredUser = await _usersRepository.AddUser(user);
            if (registeredUser == null)
            {
                return null;
            }            
            return _mapper.Map<RegisteredUserResponse>(registeredUser);
        }

    }

}
