using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MyAge = table.Column<int>(type: "int", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1PersonId = table.Column<int>(type: "int", nullable: true),
                    Player2PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameModelId);
                    table.ForeignKey(
                        name: "FK_Games_Players_Player1PersonId",
                        column: x => x.Player1PersonId,
                        principalTable: "Players",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_Player2PersonId",
                        column: x => x.Player2PersonId,
                        principalTable: "Players",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1ChoicePersonId = table.Column<int>(type: "int", nullable: true),
                    Player1Id = table.Column<int>(type: "int", nullable: false),
                    ComputerChoicePersonId = table.Column<int>(type: "int", nullable: true),
                    ComputerId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundClassId);
                    table.ForeignKey(
                        name: "FK_Rounds_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_Players_ComputerChoicePersonId",
                        column: x => x.ComputerChoicePersonId,
                        principalTable: "Players",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rounds_Players_Player1ChoicePersonId",
                        column: x => x.Player1ChoicePersonId,
                        principalTable: "Players",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player1PersonId",
                table: "Games",
                column: "Player1PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player2PersonId",
                table: "Games",
                column: "Player2PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_ComputerChoicePersonId",
                table: "Rounds",
                column: "ComputerChoicePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_Player1ChoicePersonId",
                table: "Rounds",
                column: "Player1ChoicePersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
