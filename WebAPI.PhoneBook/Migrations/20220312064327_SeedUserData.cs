using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.PhoneBook.Migrations
{
    public partial class SeedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UUID", "Company", "Location", "Mail", "Name", "Phone", "Surname" },
                values: new object[] { 1, "Amazon", "USA", "joh.doe@amazon.com", "John", "111444", "Doe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UUID", "Company", "Location", "Mail", "Name", "Phone", "Surname" },
                values: new object[] { 2, "Amazon", "USA", "ricky.more@amazon.com", "Ricky", "777888", "More" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UUID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UUID",
                keyValue: 2);
        }
    }
}
