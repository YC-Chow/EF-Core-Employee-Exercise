using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations.VarcharNVarchar
{
    public partial class ChangeDateTime2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NVarcharName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FName = table.Column<string>(type: "Nvarchar(50)", nullable: true),
                    MName = table.Column<string>(type: "Nvarchar(50)", nullable: true),
                    LName = table.Column<string>(type: "Nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DateTime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NVarcharId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VarcharName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FName = table.Column<string>(type: "varchar(50)", nullable: true),
                    MName = table.Column<string>(type: "varchar(50)", nullable: true),
                    LName = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DateTime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarcharId", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NVarcharName");

            migrationBuilder.DropTable(
                name: "VarcharName");
        }
    }
}
