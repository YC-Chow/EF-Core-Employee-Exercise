using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTimeOffset",
                table: "Employee",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTime>(
                name: "RandomDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpan",
                table: "Employee",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeId",
                table: "EmployeeAddress",
                column: "EmployeeId")
                .Annotation("SqlServer:Clustered", false)
                .Annotation("SqlServer:FillFactor", 85);

            migrationBuilder.CreateIndex(
                name: "IX_Id_FName_LName",
                table: "Employee",
                column: "Id")
                .Annotation("SqlServer:Clustered", false)
                .Annotation("SqlServer:FillFactor", 85)
                .Annotation("SqlServer:Include", new[] { "LName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeId",
                table: "EmployeeAddress");

            migrationBuilder.DropIndex(
                name: "IX_Id_FName_LName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DateTimeOffset",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RandomDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TimeSpan",
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
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyZipCode = table.Column<int>(type: "int", nullable: false),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyId", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddress_EmployeeId",
                table: "EmployeeAddress",
                column: "EmployeeId");

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
    }
}
