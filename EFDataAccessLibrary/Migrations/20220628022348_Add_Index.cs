using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class Add_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CreatedDate",
                table: "Employee",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_FName",
                table: "Employee",
                column: "FName")
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CreatedDate",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_FName",
                table: "Employee");
        }
    }
}
