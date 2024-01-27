using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class initialDenonciation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReponseSQLS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horodatage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    retribution = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReponseSQLS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DENONCIATIONS",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    delit = table.Column<int>(type: "int", nullable: false),
                    statutInfo = table.Column<int>(type: "int", nullable: false),
                    statutSuspect = table.Column<int>(type: "int", nullable: false),
                    horodatage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paysEvasion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fk_informateur = table.Column<int>(type: "int", nullable: false),
                    fk_suspect = table.Column<int>(type: "int", nullable: false),
                    fk_reponse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DENONCIATIONS", x => x.id);
                    table.ForeignKey(
                        name: "FK_DENONCIATIONS_PERSONNES_fk_informateur",
                        column: x => x.fk_informateur,
                        principalSchema: "app",
                        principalTable: "PERSONNES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DENONCIATIONS_PERSONNES_fk_suspect",
                        column: x => x.fk_suspect,
                        principalSchema: "app",
                        principalTable: "PERSONNES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DENONCIATIONS_ReponseSQLS_fk_reponse",
                        column: x => x.fk_reponse,
                        principalTable: "ReponseSQLS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DENONCIATIONS_fk_informateur",
                schema: "app",
                table: "DENONCIATIONS",
                column: "fk_informateur");

            migrationBuilder.CreateIndex(
                name: "IX_DENONCIATIONS_fk_reponse",
                schema: "app",
                table: "DENONCIATIONS",
                column: "fk_reponse");

            migrationBuilder.CreateIndex(
                name: "IX_DENONCIATIONS_fk_suspect",
                schema: "app",
                table: "DENONCIATIONS",
                column: "fk_suspect");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DENONCIATIONS",
                schema: "app");

            migrationBuilder.DropTable(
                name: "ReponseSQLS");
        }
    }
}
