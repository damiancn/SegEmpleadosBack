using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionId",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PositionId",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.UpdateData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"),
                column: "DateAcces",
                value: new DateTime(2024, 9, 26, 15, 2, 57, 83, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.UpdateData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b07b6dce-e97f-99cb-c7ad-95c202bbe464"),
                column: "DateAcces",
                value: new DateTime(2024, 9, 26, 15, 2, 57, 83, DateTimeKind.Local).AddTicks(8521));

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("abeede3b-f554-b981-0963-d9fc4290dacf"),
                column: "Code",
                value: "beneficiario");

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38bd1db4-d945-43b0-7f60-58d43707c691"),
                column: "Password",
                value: "19RbBeYHvVjD4Kthe2ilce0/eLwV9mFMztY1oMAAoFgwqtUb");

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b335379f-0be3-a7ba-1463-78f3123b8491"),
                column: "Password",
                value: "enUPdpzqcAbcoyLO3K9W/Cq7n8mHsM1UJ6g4KBS15nglYlW9");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Fk_Position",
                schema: "Catalogs",
                table: "Employees",
                column: "Fk_Position");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_Fk_Position",
                schema: "Catalogs",
                table: "Employees",
                column: "Fk_Position",
                principalSchema: "Catalogs",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_Fk_Position",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Fk_Position",
                schema: "Catalogs",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                schema: "Catalogs",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("38cfa51a-a5e4-83a2-2cfd-b3a608c8cc93"),
                column: "DateAcces",
                value: new DateTime(2024, 6, 27, 9, 23, 44, 274, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                schema: "Catalogs",
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b07b6dce-e97f-99cb-c7ad-95c202bbe464"),
                column: "DateAcces",
                value: new DateTime(2024, 6, 27, 9, 23, 44, 274, DateTimeKind.Local).AddTicks(4301));

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("abeede3b-f554-b981-0963-d9fc4290dacf"),
                column: "Code",
                value: "group");

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
    }
}
