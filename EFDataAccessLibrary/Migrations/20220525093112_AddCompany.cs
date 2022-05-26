using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class AddCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_FName",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyZipCode = table.Column<int>(type: "int", nullable: false),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyId", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyId",
                table: "Employee",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_FName",
                table: "Employee",
                column: "FName")
                .Annotation("SqlServer:Clustered", false);
        }
    }
}
