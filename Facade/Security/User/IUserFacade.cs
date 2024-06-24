namespace Facade.Security.User
{
    using Dtos.Commons;
    using Dtos.Security.Credential;
    using Dtos.Security.Login;
    using Dtos.Security.Page;
    using Dtos.Security.Rol;
    using Dtos.Security.User;
    public interface IUserFacade
    {
        Task<ResponseDto<List<UserDto>>> GetAll();
        Task<ResponseDto<UserDto>> GetById(Guid id);
        Task<ResponseDto<UserDto>> GetUserLogin(LoginDto name);
        Task<ResponseDto<UserDto>> Post(UserDto employee);
        Task<ResponseDto<UserDto>> Put(Guid id, UserDto employee);
        Task<ResponseDto<List<PageDto>>> GetRolPages(UserDto model);
        Task<ResponseDto<RolDto>> GetRolUser(UserDto model);
        Task<ResponseDto<CredentialDto>> GetMenu(LoginDto model);

    }
}