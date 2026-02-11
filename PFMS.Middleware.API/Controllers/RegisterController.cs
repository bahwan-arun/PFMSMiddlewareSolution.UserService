using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PFMS.Middleware.Application.DTO;
using PFMS.Middleware.Application.ServiceContracts;
using PFMS.Middleware.Domain.Entities;

namespace PFMS.Middleware.API.Controllers
{
    [Route("api/[controller]")] //api/auth
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly IUsersService _usersService;  
        public RegisterController(IUsersService usersService)
        {
            _usersService = usersService;           
        }       

        [HttpPost("adduser")]
        //Method to handle registration
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            //Check for invalid registerRequest
            if (request == null)
            {
                return BadRequest("Invalid registration data");
            }            
            RegisteredUserResponse ? registerResponse = await _usersService.Register(request);

            if (registerResponse == null || registerResponse.Success == false)
            {
                return BadRequest(registerResponse);
            }
            return Ok(registerResponse);
        }

        [HttpPost("getuser")]
        public async Task<IActionResult> GetUserInfo(GetUserInfoRequest request)
        {
            int UserID = request.UserID;
            PfmsUser? pfmsUser = await _usersService.GetUser(UserID);

            if (pfmsUser == null)
            {
                return BadRequest("No Record Found!!");
            }
            return Ok(pfmsUser);
        }
    }
}
