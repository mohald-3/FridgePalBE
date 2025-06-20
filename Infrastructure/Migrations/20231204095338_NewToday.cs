using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewToday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("240f60f1-9240-4b9e-a7a1-056564540e75"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("247459b7-9f9b-4773-9aab-e91a8940b8b1"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("42f536d1-82aa-49d9-82de-9383644af54f"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("9b95c75e-9971-418e-9683-f9ec424508d2"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("ef401b01-763e-46a6-8b40-ef489c3958fd"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("27f5f756-2fa5-4f1d-b32a-1196d97e0dbd"), "Björn" },
                    { new Guid("3b98fec8-c770-4c5a-9146-c9de3569893c"), "OldG" },
                    { new Guid("873665cc-1117-40d3-9a04-841da3c391f6"), "Patrik" },
                    { new Guid("8b56b661-42d0-457d-8388-7d31c48e3f0d"), "Alfred" },
                    { new Guid("a2fbf92a-8586-4b0f-b193-81ee70d3fe23"), "NewG" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("27f5f756-2fa5-4f1d-b32a-1196d97e0dbd"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("3b98fec8-c770-4c5a-9146-c9de3569893c"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("873665cc-1117-40d3-9a04-841da3c391f6"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("8b56b661-42d0-457d-8388-7d31c48e3f0d"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("a2fbf92a-8586-4b0f-b193-81ee70d3fe23"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("240f60f1-9240-4b9e-a7a1-056564540e75"), "Patrik" },
                    { new Guid("247459b7-9f9b-4773-9aab-e91a8940b8b1"), "OldG" },
                    { new Guid("42f536d1-82aa-49d9-82de-9383644af54f"), "Alfred" },
                    { new Guid("9b95c75e-9971-418e-9683-f9ec424508d2"), "Björn" },
                    { new Guid("ef401b01-763e-46a6-8b40-ef489c3958fd"), "NewG" }
                });
        }
    }
}
