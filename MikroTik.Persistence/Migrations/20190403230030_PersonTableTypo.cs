using Microsoft.EntityFrameworkCore.Migrations;

namespace MikroTik.Persistence.Migrations
{
    public partial class PersonTableTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SererId",
                table: "People",
                newName: "ServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServerId",
                table: "People",
                newName: "SererId");
        }
    }
}
