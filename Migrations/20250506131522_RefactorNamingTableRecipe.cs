using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class RefactorNamingTableRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParameterSteps_StepReceipts_StepReceiptId",
                table: "ParameterSteps");

            migrationBuilder.DropTable(
                name: "StepReceipts");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.RenameColumn(
                name: "StepReceiptId",
                table: "ParameterSteps",
                newName: "StepRecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_ParameterSteps_StepReceiptId",
                table: "ParameterSteps",
                newName: "IX_ParameterSteps_StepRecipeId");

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StepRecipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StepRecipes_RecipeId",
                table: "StepRecipes",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterSteps_StepRecipes_StepRecipeId",
                table: "ParameterSteps",
                column: "StepRecipeId",
                principalTable: "StepRecipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParameterSteps_StepRecipes_StepRecipeId",
                table: "ParameterSteps");

            migrationBuilder.DropTable(
                name: "StepRecipes");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.RenameColumn(
                name: "StepRecipeId",
                table: "ParameterSteps",
                newName: "StepReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ParameterSteps_StepRecipeId",
                table: "ParameterSteps",
                newName: "IX_ParameterSteps_StepReceiptId");

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StepReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepReceipts_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StepReceipts_ReceiptId",
                table: "StepReceipts",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterSteps_StepReceipts_StepReceiptId",
                table: "ParameterSteps",
                column: "StepReceiptId",
                principalTable: "StepReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
