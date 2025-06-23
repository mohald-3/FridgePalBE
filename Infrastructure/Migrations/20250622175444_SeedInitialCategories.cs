using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notified = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Dairy" },
                    { 2, "Meat" },
                    { 3, "Vegetables" },
                    { 4, "Fruits" },
                    { 5, "Fish" },
                    { 6, "Beverages" },
                    { 7, "Frozen" },
                    { 8, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("22b1a097-93be-4bc9-8613-99a0fd977d8d"), "Alfred" },
                    { new Guid("870fdf55-057a-42bc-bfa0-3d9520f2d32e"), "Patrik" },
                    { new Guid("a39dde9a-c014-4625-ab90-8d39afd349ee"), "Björn" },
                    { new Guid("dd3893ba-a10d-4456-879d-edee6406dfd3"), "OldG" },
                    { new Guid("fa259d8c-07e1-4984-a705-a7ec954c04c4"), "NewG" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("22b1a097-93be-4bc9-8613-99a0fd977d8d"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("870fdf55-057a-42bc-bfa0-3d9520f2d32e"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("a39dde9a-c014-4625-ab90-8d39afd349ee"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("dd3893ba-a10d-4456-879d-edee6406dfd3"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("fa259d8c-07e1-4984-a705-a7ec954c04c4"));

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
    }
}
