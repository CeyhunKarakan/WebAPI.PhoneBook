using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.PhoneBook.Migrations
{
    public partial class addedUInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInformations",
                columns: table => new
                {
                    UInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformations", x => x.UInfoID);
                });

            migrationBuilder.InsertData(
                table: "UserInformations",
                columns: new[] { "UInfoID", "Location", "Mail", "Phone", "UUID" },
                values: new object[] { 1, "TURKEY", "ck@ck.com", "777888", 1 });

            migrationBuilder.InsertData(
                table: "UserInformations",
                columns: new[] { "UInfoID", "Location", "Mail", "Phone", "UUID" },
                values: new object[] { 2, "USA", "ck@ck.com", "777888", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInformations");
        }
    }
}
