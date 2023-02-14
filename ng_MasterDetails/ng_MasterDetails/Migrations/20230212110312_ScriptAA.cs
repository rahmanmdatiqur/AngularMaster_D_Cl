using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ng_MasterDetails.Migrations
{
    public partial class ScriptAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvaliable",
                table: "Products",
                newName: "IsAvailable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Products",
                newName: "IsAvaliable");
        }
    }
}
