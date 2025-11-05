using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Szakmak.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_317 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orszagok",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    OrszagNev = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orszagok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Szakmak",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SzakmaNev = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szakmak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versenyzok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    SzakmaId = table.Column<string>(type: "TEXT", nullable: false),
                    OrszagId = table.Column<string>(type: "TEXT", nullable: false),
                    Pont = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versenyzok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versenyzok_Orszagok_OrszagId",
                        column: x => x.OrszagId,
                        principalTable: "Orszagok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Versenyzok_Szakmak_SzakmaId",
                        column: x => x.SzakmaId,
                        principalTable: "Szakmak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Versenyzok_OrszagId",
                table: "Versenyzok",
                column: "OrszagId");

            migrationBuilder.CreateIndex(
                name: "IX_Versenyzok_SzakmaId",
                table: "Versenyzok",
                column: "SzakmaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Versenyzok");

            migrationBuilder.DropTable(
                name: "Orszagok");

            migrationBuilder.DropTable(
                name: "Szakmak");
        }
    }
}
