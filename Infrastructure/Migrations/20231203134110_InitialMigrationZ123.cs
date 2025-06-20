using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationZ123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("0e4b7933-b58a-47e9-8cd9-92dbae7a59fe"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("45c243e1-4cd5-4a8d-a3c7-3ab070465b09"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("4ae56968-1e85-4e3f-a40c-a654e9db32c5"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("54203142-0668-4439-b9a3-071becf3c867"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("9a324bf8-fa49-4e73-a2f0-ae215288ccde"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1086f669-c7df-4b32-9101-7d0044b36355"), "Patrik" },
                    { new Guid("12345678-1234-5678-1234-567812345674"), "TestDogForUnitTests4" },
                    { new Guid("5305fbcd-7c40-4551-ae4e-166df1041f5d"), "NewG" },
                    { new Guid("5eaca297-37b6-4d47-ba2a-5d04577ea77f"), "Björn" },
                    { new Guid("8695398b-05e7-4f9f-8bdf-b00352d69980"), "Alfred" },
                    { new Guid("afd8b1ef-b91e-440b-ba11-115faf5e1cde"), "OldG" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("1086f669-c7df-4b32-9101-7d0044b36355"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345674"));

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

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e4b7933-b58a-47e9-8cd9-92dbae7a59fe"), "NewG" },
                    { new Guid("45c243e1-4cd5-4a8d-a3c7-3ab070465b09"), "OldG" },
                    { new Guid("4ae56968-1e85-4e3f-a40c-a654e9db32c5"), "Alfred" },
                    { new Guid("54203142-0668-4439-b9a3-071becf3c867"), "Björn" },
                    { new Guid("9a324bf8-fa49-4e73-a2f0-ae215288ccde"), "Patrik" }
                });
        }
    }
}
