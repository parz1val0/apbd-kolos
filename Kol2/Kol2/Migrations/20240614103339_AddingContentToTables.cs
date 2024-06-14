using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kol2.Migrations
{
    /// <inheritdoc />
    public partial class AddingContentToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "id", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[,]
                {
                    { 1, 12, "Piotr", "Kowalski", 60 },
                    { 2, 11, "Andrii", "Demianchuk", 59 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Burger", 2 },
                    { 2, "Cola", 1 }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { 1, "Title-1" },
                    { 2, "Title-2" }
                });

            migrationBuilder.InsertData(
                table: "Backpacks",
                columns: new[] { "CharacterId", "ItemId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 11 },
                    { 2, 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "CharacterTitels",
                columns: new[] { "CharacterId", "TitelsId", "AcquiredAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterTitels",
                keyColumns: new[] { "CharacterId", "TitelsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterTitels",
                keyColumns: new[] { "CharacterId", "TitelsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
