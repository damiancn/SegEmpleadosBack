
namespace DataAcccess.Security.Rol
{
    using DataAcccess.Util;
    using Entities.Core;
    using Entities.Models.Security;
    using Microsoft.EntityFrameworkCore;

    public class RoleDao: IRoleDao
    {
        private readonly IDataBaseContext ctx;

        public RoleDao(IDataBaseContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<RolModel> GetRolUser(UserModel user)
        {
            var rolUser = await this.ctx.RolUsers.Where(e => e.Fk_User == user.Id && e.Active).Include(e => e.Rol).Select(ru => ru.Rol).FirstOrDefaultAsync();
            SqlValidation<RolModel>.VailidateFound(rolUser, "RolUser");
            return rolUser;
        }
        public async Task<List<PageModel>> GetRolPages(UserModel user)
        {
            var rolUser = await this.ctx.RolUsers.Where(e => e.Fk_User == user.Id && e.Active).Select(e => e.Fk_Rol).ToListAsync();
            var pages = await this.ctx.RolPages.Where(e => rolUser.Contains(e.Fk_Rol) && e.Active)
                .Join(this.ctx.Pages, rolpag => rolpag.Fk_Pagina, pag => pag.Id,
                    (rolpag, pag) => new PageModel()
                    {
                        Id = pag.Id,
                        Active = pag.Active,
                        Code = pag.Code,
                        Icon = pag.Icon,
                        Name = pag.Name,
                    }).Where(e => e.Active).Distinct().ToListAsync();
            SqlValidation<PageModel>.VailidateCountList(pages, "Pages");
            return pages;
        }

    }
}
