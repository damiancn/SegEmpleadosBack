using Dtos.Security.Login;
using Dtos.Security.User;

namespace Services.Security.User
{
    public interface IUserService
    {
        Task<UserDto> GetUserLogin(LoginDto model);
    }
}
