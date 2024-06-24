
namespace Services.Security.Rol
{
    using Dtos.Security.Page;
    using Dtos.Security.Rol;
    using Dtos.Security.User;

    public interface IRolService
    {
        Task<List<PageDto>> GetRolPages(UserDto model);
        Task<RolDto> GetRolUser(UserDto model);
    }
}
