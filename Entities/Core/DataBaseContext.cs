

namespace Entities.Core
{
    using Entities.Models.Catalog;
    using Entities.Models.Security;
    using Microsoft.EntityFrameworkCore;
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options): base(options)
        {
            
        }
        #region Catalogs
        public DbSet<EmployeeModel> Employees { get; set ; }
        public DbSet<BeneficiaryModel> Beneficiaries { get; set; }
        public DbSet<PositionModel> Positions { get; set; }
        #endregion

        #region Security
        public DbSet<PageModel> Pages { get; set ; }
        public DbSet<RolModel> Roles { get; set ; }
        public DbSet<RolPageModel> RolPages { get; set ; }
        public DbSet<RolUserModel> RolUsers { get; set ; }
        public DbSet<UserModel> Users { get; set ; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RolUserModel>().HasNoKey();
            builder.Entity<RolUserModel>().HasKey(e => new { e.Fk_Rol, e.Fk_User });
            GenerateDataDb.SetTables(builder);
        }

    }
}
