
namespace Entities.Core
{
    using Entities.Models.Catalog;
    using Entities.Models.Security;
    using Microsoft.EntityFrameworkCore;

    public interface IDataBaseContext
    {
        #region Catalogs
        DbSet<EmployeeModel> Employees { get; set; }
        DbSet<BeneficiaryModel> Beneficiaries { get; set; }
        #endregion
        #region Security
        DbSet<PageModel> Pages { get; set; }
        DbSet<RolModel> Roles { get; set; }
        DbSet<RolPageModel> RolPages { get; set; }
        DbSet<RolUserModel> RolUsers { get; set; }
        DbSet<UserModel> Users { get; set; }
        #endregion
    }
}
