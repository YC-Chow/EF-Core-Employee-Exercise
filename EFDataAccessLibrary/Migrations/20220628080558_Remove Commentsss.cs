using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class RemoveCommentsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "Employee",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldComment: "<b>Hello</b> World!");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "Employee",
                type: "varchar(100)",
                nullable: false,
                comment: "<b>Hello</b> World!",
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }
    }
}
