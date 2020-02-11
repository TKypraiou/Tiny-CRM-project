using Microsoft.EntityFrameworkCore.Migrations;

namespace TinyCrm.Core.Migrations
{
    public partial class TinyCRM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                schema: "core",
                table: "Customer",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                schema: "core",
                table: "Customer",
                newName: "FirstName");

            migrationBuilder.AlterColumn<decimal>(
                name: "VatNumber",
                schema: "core",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "core");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "core",
                table: "Customer",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "core",
                table: "Customer",
                newName: "Firstname");

            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                schema: "core",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}
