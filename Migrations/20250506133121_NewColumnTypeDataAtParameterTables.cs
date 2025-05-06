using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnTypeDataAtParameterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "StepRecipes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Recipes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeData",
                table: "ParameterTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeData",
                table: "ParameterSteps",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ParameterTypes",
                columns: new[] { "Id", "Description", "Name", "TypeData" },
                values: new object[] { new Guid("7b0ff93a-c215-4b84-ad79-818c69f7b175"), "Keterangan", "Description", "text" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: new Guid("7b0ff93a-c215-4b84-ad79-818c69f7b175"));

            migrationBuilder.DropColumn(
                name: "Title",
                table: "StepRecipes");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "TypeData",
                table: "ParameterTypes");

            migrationBuilder.DropColumn(
                name: "TypeData",
                table: "ParameterSteps");
        }
    }
}
