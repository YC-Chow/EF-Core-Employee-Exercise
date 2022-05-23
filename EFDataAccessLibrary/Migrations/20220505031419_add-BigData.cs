using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccessLibrary.Migrations
{
    public partial class addBigData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BigData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandomString = table.Column<string>(type: "VarChar(max)", nullable: true),
                    RandomString2 = table.Column<string>(type: "VarChar(max)", nullable: true),
                    RandomInt = table.Column<int>(type: "int", nullable: false),
                    RandomInt2 = table.Column<int>(type: "int", nullable: false),
                    RandomDateTime = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    RandomDateTime2 = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    RandomDecimal = table.Column<decimal>(type: "Decimal(38,19)", nullable: false),
                    RandomDecimal2 = table.Column<decimal>(type: "Decimal(38,19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigDataId", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BigData");
        }
    }
}
