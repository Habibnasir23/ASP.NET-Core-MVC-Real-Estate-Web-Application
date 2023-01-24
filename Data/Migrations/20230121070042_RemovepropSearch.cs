using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    public partial class RemovepropSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "propSearch",
                table: "RealEstate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "propSearch",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
