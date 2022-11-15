using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Database.Migrations
{
    public partial class SeedingPeopletoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "City", "Name", "PhoneNumber" },
                values: new object[] { 1, "Gothenburg", "Siavash Gosheh", "xxxx-xxx666" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "City", "Name", "PhoneNumber" },
                values: new object[] { 2, "Central Pennsylvania", "Maxwell T Bird", "Mr. Max Tv @ Youtube" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "City", "Name", "PhoneNumber" },
                values: new object[] { 3, "Gdansk", "Nergal", "666" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
