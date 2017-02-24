using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teamdare.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdventureId = table.Column<Guid>(nullable: false),
                    HeroId = table.Column<Guid>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsStarted = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppId = table.Column<string>(nullable: true),
                    AppNick = table.Column<string>(nullable: true),
                    ChallengeId = table.Column<Guid>(nullable: true),
                    ConversationId = table.Column<string>(nullable: true),
                    GameMasterId = table.Column<Guid>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Nick = table.Column<string>(nullable: true),
                    ServiceUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_GameMasters_GameMasterId",
                        column: x => x.GameMasterId,
                        principalTable: "GameMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adventures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FinishedImageUrl = table.Column<string>(nullable: true),
                    FinishedText = table.Column<string>(nullable: true),
                    GameMasterId = table.Column<Guid>(nullable: false),
                    HeroId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adventures_GameMasters_GameMasterId",
                        column: x => x.GameMasterId,
                        principalTable: "GameMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adventures_Players_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdventureId = table.Column<int>(nullable: false),
                    AdventureId1 = table.Column<Guid>(nullable: true),
                    PlayerId = table.Column<int>(nullable: false),
                    PlayerId1 = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Adventures_AdventureId1",
                        column: x => x.AdventureId1,
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rewards_Players_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_GameMasterId",
                table: "Adventures",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_HeroId",
                table: "Adventures",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_AdventureId",
                table: "Challenges",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_HeroId",
                table: "Challenges",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ChallengeId",
                table: "Players",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameMasterId",
                table: "Players",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_AdventureId1",
                table: "Rewards",
                column: "AdventureId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_PlayerId1",
                table: "Rewards",
                column: "PlayerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Players_HeroId",
                table: "Challenges",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Adventures_AdventureId",
                table: "Challenges",
                column: "AdventureId",
                principalTable: "Adventures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adventures_GameMasters_GameMasterId",
                table: "Adventures");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_GameMasters_GameMasterId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Adventures_Players_HeroId",
                table: "Adventures");

            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Players_HeroId",
                table: "Challenges");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "GameMasters");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Adventures");
        }
    }
}
