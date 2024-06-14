using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kol2.Migrations
{
    /// <inheritdoc />
    public partial class AddingCharacterTitlesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterTitels",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    TitelsId = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTitels", x => new { x.CharacterId, x.TitelsId });
                    table.ForeignKey(
                        name: "FK_CharacterTitels_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTitels_Titles_TitelsId",
                        column: x => x.TitelsId,
                        principalTable: "Titles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTitels_TitelsId",
                table: "CharacterTitels",
                column: "TitelsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterTitels");
        }
    }
}
