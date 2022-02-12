using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoSchool.Migrations
{
    public partial class RenameWeaponColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Weapons",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Weapons",
                newName: "MyProperty");
        }
    }
}
