using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReceiptInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSeederParameterTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParameterTypes",
                columns: new[] { "Id", "Description", "Name", "TypeData" },
                values: new object[,]
                {
                    { new Guid("35fee709-1568-495c-9163-7ee9ddf7784a"), "Penjelasan tentang langkah", "Deskripsi", "text" },
                    { new Guid("b4e54ea5-9e64-42db-8fcc-ff3dd25e085e"), "Lama waktu pelaksanaan langkah", "Durasi", "integer" },
                    { new Guid("be0c8dd8-93db-494a-8a27-8fc69e4bf01e"), "Suhu yang dibutuhkan", "Suhu", "float" },
                    { new Guid("c40582ab-bfcd-4a7e-bf54-33ef61aec5ed"), "Tekanan pada alat yang digunakan", "tekanan", "float" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: new Guid("35fee709-1568-495c-9163-7ee9ddf7784a"));

            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: new Guid("b4e54ea5-9e64-42db-8fcc-ff3dd25e085e"));

            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: new Guid("be0c8dd8-93db-494a-8a27-8fc69e4bf01e"));

            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: new Guid("c40582ab-bfcd-4a7e-bf54-33ef61aec5ed"));
        }
    }
}
