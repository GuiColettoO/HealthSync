using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthSync.Migrations
{
    /// <inheritdoc />
    public partial class finalizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_INFOUSER",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    TypeRestrictionMedic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeRestrictionTrainne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_INFOUSER", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USERMEDIC",
                columns: table => new
                {
                    ID_USERMEDIC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NumberofCredential = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USERMEDIC", x => x.ID_USERMEDIC);
                });

            migrationBuilder.CreateTable(
                name: "TB_USERTRAINNER",
                columns: table => new
                {
                    ID_USERTRAINNER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NumberofCredential = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USERTRAINNER", x => x.ID_USERTRAINNER);
                });

            migrationBuilder.CreateTable(
                name: "TB_MENU",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breakfast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lunch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AfternoonSnack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dinner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MENU", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_MENU_TB_USERMEDIC_MedicId",
                        column: x => x.MedicId,
                        principalTable: "TB_USERMEDIC",
                        principalColumn: "ID_USERMEDIC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_INFOTRAINNER",
                columns: table => new
                {
                    TrainnerId = table.Column<int>(type: "int", nullable: false),
                    InfoUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_INFOTRAINNER", x => new { x.TrainnerId, x.InfoUserId });
                    table.ForeignKey(
                        name: "FK_TB_INFOTRAINNER_TB_INFOUSER_InfoUserId",
                        column: x => x.InfoUserId,
                        principalTable: "TB_INFOUSER",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TB_INFOTRAINNER_TB_USERTRAINNER_TrainnerId",
                        column: x => x.TrainnerId,
                        principalTable: "TB_USERTRAINNER",
                        principalColumn: "ID_USERTRAINNER");
                });

            migrationBuilder.CreateTable(
                name: "TB_WORKOUT",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeWorkout = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdForWeek = table.Column<int>(type: "int", nullable: false),
                    QtdTime = table.Column<int>(type: "int", nullable: false),
                    TrainnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_WORKOUT", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_WORKOUT_TB_USERTRAINNER_TrainnerId",
                        column: x => x.TrainnerId,
                        principalTable: "TB_USERTRAINNER",
                        principalColumn: "ID_USERTRAINNER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_INFOMENU",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    InfoUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_INFOMENU", x => new { x.MenuId, x.InfoUserId });
                    table.ForeignKey(
                        name: "FK_TB_INFOMENU_TB_INFOUSER_InfoUserId",
                        column: x => x.InfoUserId,
                        principalTable: "TB_INFOUSER",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TB_INFOMENU_TB_MENU_MenuId",
                        column: x => x.MenuId,
                        principalTable: "TB_MENU",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_INFOMENU_InfoUserId",
                table: "TB_INFOMENU",
                column: "InfoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_INFOTRAINNER_InfoUserId",
                table: "TB_INFOTRAINNER",
                column: "InfoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MENU_MedicId",
                table: "TB_MENU",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_WORKOUT_TrainnerId",
                table: "TB_WORKOUT",
                column: "TrainnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_INFOMENU");

            migrationBuilder.DropTable(
                name: "TB_INFOTRAINNER");

            migrationBuilder.DropTable(
                name: "TB_WORKOUT");

            migrationBuilder.DropTable(
                name: "TB_MENU");

            migrationBuilder.DropTable(
                name: "TB_INFOUSER");

            migrationBuilder.DropTable(
                name: "TB_USERTRAINNER");

            migrationBuilder.DropTable(
                name: "TB_USERMEDIC");
        }
    }
}
