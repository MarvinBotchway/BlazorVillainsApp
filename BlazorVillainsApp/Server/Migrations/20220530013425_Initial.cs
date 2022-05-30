using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorVillainsApp.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VillainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Villains_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "DC" });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Marvel" });

            migrationBuilder.InsertData(
                table: "Villains",
                columns: new[] { "Id", "ComicId", "FirstName", "LastName", "VillainName" },
                values: new object[] { 1, 2, "Jack", "Napier", "Venom" });

            migrationBuilder.InsertData(
                table: "Villains",
                columns: new[] { "Id", "ComicId", "FirstName", "LastName", "VillainName" },
                values: new object[] { 2, 1, "Eddie", "Brock", "Joker" });

            migrationBuilder.CreateIndex(
                name: "IX_Villains_ComicId",
                table: "Villains",
                column: "ComicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villains");

            migrationBuilder.DropTable(
                name: "Comics");
        }
    }
}
