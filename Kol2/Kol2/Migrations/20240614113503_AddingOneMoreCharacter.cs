using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kol2.Migrations
{
    /// <inheritdoc />
    public partial class AddingOneMoreCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "id", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[] { 3, 10, "Guy", "random", 60 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "Name", "Weight" },
                values: new object[] { 3, "Pistol", 4 });

            migrationBuilder.InsertData(
                table: "Backpacks",
                columns: new[] { "CharacterId", "ItemId", "Amount" },
                values: new object[] { 3, 2, 8 });

            migrationBuilder.InsertData(
                table: "CharacterTitels",
                columns: new[] { "CharacterId", "TitelsId", "AcquiredAt" },
                values: new object[] { 3, 2, new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterTitels",
                keyColumns: new[] { "CharacterId", "TitelsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
