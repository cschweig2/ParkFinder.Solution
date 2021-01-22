using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkFinder.Migrations
{
    public partial class AddSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "City", "ParkName", "ParkType", "State", "Status", "Website" },
                values: new object[] { 1, "Crater Lake", "Crater Lake", "National Park", "OR", "Open", "https://www.nps.gov/crla/index.htm" });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "City", "ParkName", "ParkType", "State", "Status", "Website" },
                values: new object[] { 2, "Batsto", "New Jersey Pinelands", "National Reserve", "NJ", "Open", "https://www.nps.gov/pine/index.htm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);
        }
    }
}
