using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorWithIdentity.Server.Migrations
{
    public partial class AddWeightToPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeightFrist",
                table: "WeightingPlans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeightSecond",
                table: "WeightingPlans",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeightFrist",
                table: "WeightingPlans");

            migrationBuilder.DropColumn(
                name: "WeightSecond",
                table: "WeightingPlans");
        }
    }
}
