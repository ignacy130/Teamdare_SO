using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teamdare.Database.Migrations
{
    public partial class Initial : Migration
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
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameMasterId = table.Column<Guid>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Nick = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
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
                    GameMasterId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adventures_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdventureId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenges_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdventureId = table.Column<Guid>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rewards_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_GameMasterId",
                table: "Adventures",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_PlayerId",
                table: "Adventures",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_AdventureId",
                table: "Challenges",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_PlayerId",
                table: "Challenges",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameMasterId",
                table: "Players",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_AdventureId",
                table: "Rewards",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_PlayerId",
                table: "Rewards",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Adventures");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "GameMasters");
        }
    }
}
