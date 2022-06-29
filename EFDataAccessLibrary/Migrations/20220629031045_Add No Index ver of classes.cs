using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class AddNoIndexverofclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeNoIndex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "varchar(100)", nullable: false),
                    MName = table.Column<string>(type: "varchar(100)", nullable: true),
                    LName = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeNoIndex", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddressNoINdex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "varchar(200)", nullable: false),
                    Address2 = table.Column<string>(type: "varchar(200)", nullable: true),
                    Address3 = table.Column<string>(type: "varchar(200)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddressNoINdex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAddressNoINdex_EmployeeNoIndex_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeNoIndex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddressNoINdex_EmployeeId",
                table: "EmployeeAddressNoINdex",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAddressNoINdex");

            migrationBuilder.DropTable(
                name: "EmployeeNoIndex");
        }
    }
}
