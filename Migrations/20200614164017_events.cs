using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Draggable = table.Column<bool>(nullable: false),
                    EventType = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    StayType = table.Column<string>(nullable: true),
                    Km = table.Column<string>(nullable: true),
                    Fair = table.Column<string>(nullable: true),
                    DaRate = table.Column<string>(nullable: true),
                    TimeIn = table.Column<DateTime>(nullable: false),
                    TimeOut = table.Column<DateTime>(nullable: false),
                    TotalTime = table.Column<string>(nullable: true),
                    Da = table.Column<string>(nullable: true),
                    DaPercent = table.Column<string>(nullable: true),
                    Total = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
