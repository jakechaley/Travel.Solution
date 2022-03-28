using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Places",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Places",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 1,
                column: "State",
                value: "Washington");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 2,
                column: "State",
                value: "Oregon");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 3,
                column: "State",
                value: "California");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 4,
                column: "State",
                value: "British Columbia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Places",
                newName: "Name");
        }
    }
}
