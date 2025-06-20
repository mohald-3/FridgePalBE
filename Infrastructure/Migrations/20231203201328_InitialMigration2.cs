using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("1086f669-c7df-4b32-9101-7d0044b36355"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("5305fbcd-7c40-4551-ae4e-166df1041f5d"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("5eaca297-37b6-4d47-ba2a-5d04577ea77f"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("8695398b-05e7-4f9f-8bdf-b00352d69980"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("afd8b1ef-b91e-440b-ba11-115faf5e1cde"));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

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
                    { new Guid("1086f669-c7df-4b32-9101-7d0044b36355"), "Patrik" },
                    { new Guid("5305fbcd-7c40-4551-ae4e-166df1041f5d"), "NewG" },
                    { new Guid("5eaca297-37b6-4d47-ba2a-5d04577ea77f"), "Björn" },
                    { new Guid("8695398b-05e7-4f9f-8bdf-b00352d69980"), "Alfred" },
                    { new Guid("afd8b1ef-b91e-440b-ba11-115faf5e1cde"), "OldG" }
                });
        }
    }
}
