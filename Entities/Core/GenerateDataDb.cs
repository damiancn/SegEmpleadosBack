namespace Entities.Core
{
    using Entities.Models.Catalog;
    using Entities.Models.Security;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Cryptography;
    public static class GenerateDataDb
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Iterations = 1000;
        public static void SetTables(ModelBuilder builder)
        {
            builder.Entity<PositionModel>().HasData(SetPosition());
            builder.Entity<EmployeeModel>().HasData(SetEmployee());
            builder.Entity<BeneficiaryModel>().HasData(SetBeneficiary());
            builder.Entity<UserModel>().HasData(SetUsers());
            builder.Entity<RolModel>().HasData(SetRole());
            builder.Entity<PageModel>().HasData(SetPage());
            builder.Entity<RolPageModel>().HasData(SetRolPage());
            builder.Entity<RolUserModel>().HasData(SetRolUser());
        }
        public static PositionModel SetPosition()
        {
            return new PositionModel()
            {
                Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "Empleado",
                Active = true,
            };
        }
        public static List<EmployeeModel> SetEmployee()
        {
            return new List<EmployeeModel>()
            {
                new EmployeeModel()
                {
                    Id = Guid.Parse("b07b6dce-e97f-99cb-c7ad-95c202bbe464"),
                    Name = "Damian",
                    FirstName = "Carreon",
                    SeconLastName = "Neria",
                    DateAcces = DateTime.Now,
                    BirthDate = new DateTime(1997, 12,12, 15, 30, 45),
                    Age = (DateTime.Now.Year - new DateTime(1997, 12, 12, 15, 30, 45).Year) - (DateTime.Now.Month < new DateTime(1997, 12, 12, 15, 30, 45).Month || (DateTime.Now.Month == new DateTime(1997, 12, 12, 15, 30, 45).Month && DateTime.Now.Day < new DateTime(1997, 12, 12, 15, 30, 45).Day) ? 1 : 0),
                    Fotography = "",
                    Salary = 10000.05m,
                    Fk_Position = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
                },
                new EmployeeModel()
                {
                    Id = Guid.Parse("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"),
                    Name = "Gerardo",
                    FirstName = "Perez",
                    SeconLastName = "Perez",
                    DateAcces = DateTime.Now,
                    BirthDate = new DateTime(1999, 02, 01, 09, 00, 45),
                    Age = (DateTime.Now.Year - new DateTime(1999, 02, 01, 09, 00, 45).Year) - (DateTime.Now.Month < new DateTime(1999, 02, 01, 09, 00, 45).Month || (DateTime.Now.Month == new DateTime(1999, 02, 01, 09, 00, 45).Month && DateTime.Now.Day < new DateTime(1999, 02, 01, 09, 00, 45).Day) ? 1 : 0),
                    Fotography = "",
                    Salary = 10000.03m,
                    Fk_Position = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
                }
            };
        }
        public static BeneficiaryModel SetBeneficiary()
        {
            return new BeneficiaryModel()
            {
                Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "Juan",
                FirstName = "Perez",
                SeconLastName = "Perez",
                Relationship = " Hermano",
                Fk_Employee = Guid.Parse("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93")
            };
        }
        public static List<UserModel> SetUsers()
        {
            return new List<UserModel>()
            {
                new UserModel()
                {
                    Id = Guid.Parse("38bd1db4-d945-43b0-7f60-58d43707c691"),
                    Name = "Administrador",
                    Password = HashPassword("admin"),
                    Active = true,
                    Fk_Employee = Guid.Parse("b07b6dce-e97f-99cb-c7ad-95c202bbe464"),
                },
                new UserModel()
                {
                    Id = Guid.Parse("b335379f-0be3-a7ba-1463-78f3123b8491"),
                    Name = "Usuario",
                    Password = HashPassword("Usuario"),
                    Active = true,
                    Fk_Employee = Guid.Parse("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"),
                }
            };
        }
        public static List<RolModel> SetRole()
        {
            return new List<RolModel>()
            {
                new RolModel()
                {
                Id=Guid.Parse("592231c0-56b5-cb5e-3ad8-db295dbc1c84"),
                Code ="ADMIN",
                Name="Administrador",
                Active=true,
                },
                new RolModel()
                {
                Id=Guid.Parse("cc504b2d-0731-52df-34fb-bc3e1e2e9577"),
                Code ="User",
                Name="Usuario",
                Active =true,
                },
            };
        }
        public static List<PageModel> SetPage()
        {
            return new List<PageModel>()
            {
                new PageModel()
                {
                    Id=Guid.Parse("9ad65152-94ec-71cd-7a19-77a4e4785020"),
                    Icon="person",
                    Code="empleado",
                    Name="Empleados",
                    Active=true,
                },
                new PageModel()
                {
                    Id=Guid.Parse("abeede3b-f554-b981-0963-d9fc4290dacf"),
                    Icon="manage_accounts",
                    Code="beneficiario",
                    Name="Beneficiarios",
                    Active=true,
                },

            };
        }
        public static List<RolPageModel> SetRolPage()
        {
            return new List<RolPageModel>()
            {
                new RolPageModel()
                {
                    Id=Guid.Parse("dc7cf1fd-569f-dc57-aab0-dcfb973b822c"),
                    Fk_Rol = Guid.Parse("592231c0-56b5-cb5e-3ad8-db295dbc1c84"),
                    Fk_Pagina= Guid.Parse("9ad65152-94ec-71cd-7a19-77a4e4785020"),
                    Active = true,

                },
                  new RolPageModel()
                {
                    Id=Guid.Parse("6a7ab137-f6a2-6715-1a3c-e38ec055ac78"),
                    Fk_Rol = Guid.Parse("592231c0-56b5-cb5e-3ad8-db295dbc1c84"),
                    Fk_Pagina= Guid.Parse("abeede3b-f554-b981-0963-d9fc4290dacf"),
                    Active = true,

                },
                new RolPageModel()
                {
                    Id=Guid.Parse("4a3613c8-f887-0c86-789d-578ae3aa0ec3"),
                    Fk_Rol = Guid.Parse("cc504b2d-0731-52df-34fb-bc3e1e2e9577"),
                    Fk_Pagina= Guid.Parse("9ad65152-94ec-71cd-7a19-77a4e4785020"),
                    Active = true,
                },
                 new RolPageModel()
                {
                    Id=Guid.Parse("ffaa1f38-746a-32c6-bca9-75449c85d235"),
                    Fk_Rol = Guid.Parse("cc504b2d-0731-52df-34fb-bc3e1e2e9577"),
                    Fk_Pagina= Guid.Parse("abeede3b-f554-b981-0963-d9fc4290dacf"),
                    Active = true,
                },
            };
        }
        public static List<RolUserModel> SetRolUser()
        {
            return new List<RolUserModel>()
            {
                new RolUserModel()
                {
                    Fk_Rol = Guid.Parse("592231c0-56b5-cb5e-3ad8-db295dbc1c84"),
                    Fk_User = Guid.Parse("38bd1db4-d945-43b0-7f60-58d43707c691"),
                    Active=true,
                },
                new RolUserModel()
                {
                    Fk_Rol = Guid.Parse("cc504b2d-0731-52df-34fb-bc3e1e2e9577"),
                    Fk_User = Guid.Parse("b335379f-0be3-a7ba-1463-78f3123b8491"),
                    Active = true
                },
           };
        }


        private static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

    }
}

