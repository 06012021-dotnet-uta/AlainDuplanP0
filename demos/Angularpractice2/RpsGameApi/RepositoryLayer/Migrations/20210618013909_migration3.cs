using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Players_ComputerChoicePersonId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Players_Player1ChoicePersonId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_ComputerChoicePersonId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_Player1ChoicePersonId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "ComputerChoicePersonId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Player1ChoicePersonId",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "ComputerChoice",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player1Choice",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerChoice",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Player1Choice",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "ComputerChoicePersonId",
                table: "Rounds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Player1ChoicePersonId",
                table: "Rounds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_ComputerChoicePersonId",
                table: "Rounds",
                column: "ComputerChoicePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_Player1ChoicePersonId",
                table: "Rounds",
                column: "Player1ChoicePersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Players_ComputerChoicePersonId",
                table: "Rounds",
                column: "ComputerChoicePersonId",
                principalTable: "Players",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Players_Player1ChoicePersonId",
                table: "Rounds",
                column: "Player1ChoicePersonId",
                principalTable: "Players",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
