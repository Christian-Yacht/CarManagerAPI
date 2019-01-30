using Microsoft.EntityFrameworkCore.Migrations;

namespace APIassignment2.Migrations
{
    public partial class CarAdjusted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarUserName",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarUserName",
                table: "Cars",
                nullable: true);
        }
    }
}
