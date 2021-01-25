using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkFinder.Migrations
{
    public partial class AddSeededUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FirstName", "LastName", "Password", "Token", "Username" },
                values: new object[] { 3, "test", "user", "test", null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
