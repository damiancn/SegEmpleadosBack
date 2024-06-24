using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Beneficiary",
                table: "Beneficiary");

            migrationBuilder.EnsureSchema(
                name: "Catalogs");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employees",
                newSchema: "Catalogs");

            migrationBuilder.RenameTable(
                name: "Beneficiary",
                newName: "Beneficiaries",
                newSchema: "Catalogs");

            migrationBuilder.AlterColumn<string>(
                name: "Fotography",
                schema: "Catalogs",
                table: "Employees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "Fk_Employee",
                schema: "Catalogs",
                table: "Beneficiaries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beneficiaries",
                schema: "Catalogs",
                table: "Beneficiaries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pages",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Active = table.Column<bool>(type: "bit", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Fk_Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Employees_Fk_Employee",
                        column: x => x.Fk_Employee,
                        principalSchema: "Catalogs",
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolPages",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_Rol = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_Pagina = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolPages_Pages_Fk_Pagina",
                        column: x => x.Fk_Pagina,
                        principalSchema: "Security",
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPages_Roles_Fk_Rol",
                        column: x => x.Fk_Rol,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUsers",
                schema: "Security",
                columns: table => new
                {
                    Fk_Rol = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fk_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsers", x => new { x.Fk_Rol, x.Fk_User });
                    table.ForeignKey(
                        name: "FK_RolUsers_Roles_Fk_Rol",
                        column: x => x.Fk_Rol,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsers_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalogs",
                table: "Employees",
                columns: new[] { "Id", "Age", "BirthDate", "DateAcces", "FirstName", "Fotography", "Name", "Position", "Salary", "SeconLastName" },
                values: new object[,]
                {
                    { new Guid("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"), 25, new DateTime(1999, 2, 1, 9, 0, 45, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 11, 17, 22, 190, DateTimeKind.Local).AddTicks(4808), "Perez", "", "Gerardo", "Empleado", 10000.03m, "Perez" },
                    { new Guid("b07b6dce-e97f-99cb-c7ad-95c202bbe464"), 26, new DateTime(1997, 12, 12, 15, 30, 45, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 11, 17, 22, 190, DateTimeKind.Local).AddTicks(4553), "Carreon", "", "Damian", "Empleado", 10000.05m, "Neria" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Pages",
                columns: new[] { "Id", "Active", "Code", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("9ad65152-94ec-71cd-7a19-77a4e4785020"), true, "empleado", "person", "Empleados" },
                    { new Guid("abeede3b-f554-b981-0963-d9fc4290dacf"), true, "group", "manage_accounts", "Beneficiarios" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Roles",
                columns: new[] { "Id", "Active", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("592231c0-56b5-cb5e-3ad8-db295dbc1c84"), true, "ADMIN", "Administrador" },
                    { new Guid("cc504b2d-0731-52df-34fb-bc3e1e2e9577"), true, "User", "Usuario" }
                });

            migrationBuilder.InsertData(
                schema: "Catalogs",
                table: "Beneficiaries",
                columns: new[] { "Id", "FirstName", "Fk_Employee", "Name", "Relationship", "SeconLastName" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Perez", new Guid("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"), "Juan", " Hermano", "Perez" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "RolPages",
                columns: new[] { "Id", "Active", "Fk_Pagina", "Fk_Rol" },
                values: new object[,]
                {
                    { new Guid("4a3613c8-f887-0c86-789d-578ae3aa0ec3"), true, new Guid("9ad65152-94ec-71cd-7a19-77a4e4785020"), new Guid("cc504b2d-0731-52df-34fb-bc3e1e2e9577") },
                    { new Guid("6a7ab137-f6a2-6715-1a3c-e38ec055ac78"), true, new Guid("abeede3b-f554-b981-0963-d9fc4290dacf"), new Guid("592231c0-56b5-cb5e-3ad8-db295dbc1c84") },
                    { new Guid("dc7cf1fd-569f-dc57-aab0-dcfb973b822c"), true, new Guid("9ad65152-94ec-71cd-7a19-77a4e4785020"), new Guid("592231c0-56b5-cb5e-3ad8-db295dbc1c84") },
                    { new Guid("ffaa1f38-746a-32c6-bca9-75449c85d235"), true, new Guid("abeede3b-f554-b981-0963-d9fc4290dacf"), new Guid("cc504b2d-0731-52df-34fb-bc3e1e2e9577") }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Users",
                columns: new[] { "Id", "Active", "Fk_Employee", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("38bd1db4-d945-43b0-7f60-58d43707c691"), true, new Guid("b07b6dce-e97f-99cb-c7ad-95c202bbe464"), "Administrador", "sdK5nk7axI/6lkjktiFZ1H6po87xQrStMYEpu9m1/k19JVwW" },
                    { new Guid("b335379f-0be3-a7ba-1463-78f3123b8491"), true, new Guid("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"), "Usuario", "4DP4QXMKX2jnabAMKJpJuHRfQfR3ggufp5/Qlem8y7FFov6M" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "RolUsers",
                columns: new[] { "Fk_Rol", "Fk_User", "Active" },
                values: new object[] { new Guid("592231c0-56b5-cb5e-3ad8-db295dbc1c84"), new Guid("38bd1db4-d945-43b0-7f60-58d43707c691"), true });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "RolUsers",
                columns: new[] { "Fk_Rol", "Fk_User", "Active" },
                values: new object[] { new Guid("cc504b2d-0731-52df-34fb-bc3e1e2e9577"), new Guid("b335379f-0be3-a7ba-1463-78f3123b8491"), true });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_Fk_Employee",
                schema: "Catalogs",
                table: "Beneficiaries",
                column: "Fk_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_RolPages_Fk_Pagina",
                schema: "Security",
                table: "RolPages",
                column: "Fk_Pagina");

            migrationBuilder.CreateIndex(
                name: "IX_RolPages_Fk_Rol",
                schema: "Security",
                table: "RolPages",
                column: "Fk_Rol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsers_Fk_User",
                schema: "Security",
                table: "RolUsers",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Fk_Employee",
                schema: "Security",
                table: "Users",
                column: "Fk_Employee",
                unique: true,
                filter: "[Fk_Employee] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Employees_Fk_Employee",
                schema: "Catalogs",
                table: "Beneficiaries",
                column: "Fk_Employee",
                principalSchema: "Catalogs",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Employees_Fk_Employee",
                schema: "Catalogs",
                table: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "RolPages",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "RolUsers",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Pages",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beneficiaries",
                schema: "Catalogs",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_Fk_Employee",
                schema: "Catalogs",
                table: "Beneficiaries");

            migrationBuilder.DeleteData(
                schema: "Catalogs",
                table: "Beneficiaries",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"));

            migrationBuilder.DeleteData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b07b6dce-e97f-99cb-c7ad-95c202bbe464"));

            migrationBuilder.DropColumn(
                name: "Fk_Employee",
                schema: "Catalogs",
                table: "Beneficiaries");

            migrationBuilder.RenameTable(
                name: "Employees",
                schema: "Catalogs",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Beneficiaries",
                schema: "Catalogs",
                newName: "Beneficiary");

            migrationBuilder.AlterColumn<string>(
                name: "Fotography",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beneficiary",
                table: "Beneficiary",
                column: "Id");
        }
    }
}
