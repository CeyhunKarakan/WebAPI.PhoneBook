using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.PhoneBook.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UUID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UUID", "Company", "Name", "Surname" },
                values: new object[] { 1, "Amazon", "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UUID", "Company", "Name", "Surname" },
                values: new object[] { 2, "Amazon", "Ricky", "More" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
