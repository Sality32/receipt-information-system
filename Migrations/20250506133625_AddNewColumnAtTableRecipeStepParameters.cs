using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnAtTableRecipeStepParameters : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
