namespace DataAcccess.Security.Rol
{
    using DataAcccess.Util;
    using Entities.Models.Security;

    public interface IRoleDao
    {
        Task<List<PageModel>> GetRolPages(UserModel model);
        Task<RolModel> GetRolUser(UserModel model);
    }
}
