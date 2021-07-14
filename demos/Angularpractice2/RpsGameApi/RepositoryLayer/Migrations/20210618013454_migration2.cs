using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Games_GameId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Player1Id",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "GameModelId",
                table: "Rounds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameModelId",
                table: "Rounds",
                column: "GameModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Games_GameModelId",
                table: "Rounds",
                column: "GameModelId",
                principalTable: "Games",
                principalColumn: "GameModelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Games_GameModelId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_GameModelId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "GameModelId",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player1Id",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Games_GameId",
                table: "Rounds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
