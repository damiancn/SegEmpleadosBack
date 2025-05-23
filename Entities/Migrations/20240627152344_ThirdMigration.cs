using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "Fk_Position",
                schema: "Catalogs",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                schema: "Catalogs",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"),
                columns: new[] { "DateAcces", "Fk_Position" },
                values: new object[] { new DateTime(2024, 6, 27, 9, 23, 44, 274, DateTimeKind.Local).AddTicks(4322), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });

            migrationBuilder.UpdateData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b07b6dce-e97f-99cb-c7ad-95c202bbe464"),
                columns: new[] { "DateAcces", "Fk_Position" },
                values: new object[] { new DateTime(2024, 6, 27, 9, 23, 44, 274, DateTimeKind.Local).AddTicks(4301), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });

            migrationBuilder.InsertData(
                schema: "Catalogs",
                table: "Positions",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), true, "Empleado" });

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38bd1db4-d945-43b0-7f60-58d43707c691"),
                column: "Password",
                value: "ijnmi9luxmLgeS1Dm76ljpiRuk7HWxLTGkLu2F2zP8qsrNLC");

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b335379f-0be3-a7ba-1463-78f3123b8491"),
                column: "Password",
                value: "T0zx1afFqn4nEQFOxnf2MrJYkG6v7vOZq/UvqL7alJRBFn/S");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                schema: "Catalogs",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                schema: "Catalogs",
                table: "Employees",
                column: "PositionId",
                principalSchema: "Catalogs",
                principalTable: "Positions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionId",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Fk_Position",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PositionId",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                schema: "Catalogs",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"),
                columns: new[] { "DateAcces", "Position" },
                values: new object[] { new DateTime(2024, 6, 24, 11, 17, 22, 190, DateTimeKind.Local).AddTicks(4808), "Empleado" });

            migrationBuilder.UpdateData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b07b6dce-e97f-99cb-c7ad-95c202bbe464"),
                columns: new[] { "DateAcces", "Position" },
                values: new object[] { new DateTime(2024, 6, 24, 11, 17, 22, 190, DateTimeKind.Local).AddTicks(4553), "Empleado" });

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38bd1db4-d945-43b0-7f60-58d43707c691"),
                column: "Password",
                value: "sdK5nk7axI/6lkjktiFZ1H6po87xQrStMYEpu9m1/k19JVwW");

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b335379f-0be3-a7ba-1463-78f3123b8491"),
                column: "Password",
                value: "4DP4QXMKX2jnabAMKJpJuHRfQfR3ggufp5/Qlem8y7FFov6M");
        }
    }
}
